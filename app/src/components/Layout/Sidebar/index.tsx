import { FC, memo, ReactNode, useCallback, useEffect, useMemo, useState } from "react";
import IProps from "./interfaces/IProps";
import IMenuItem from "./interfaces/IMenuItem";
import KeyItemActionType from "./SidebarItem/types/KeyItemActionType";
import * as S from "./styles";
import { MdSearch, MdSettingsBackupRestore, MdVisibilityOff, MdVisibility, MdOutlinePushPin, MdOpenWith, MdBusinessCenter, MdMoreVert } from "react-icons/md";
import routes from "../../../config/routes";
import EnumMenuGroup from "../../../config/enums/EnumMenuGroup";
import EnumFlagMenuItem from "./enums/EnumFlagMenuItem";
import SidebarItem from "./SidebarItem";
import { useTranslate } from "../../../contexts/TranslateContext";
import IconButton from "../../IconButton";
import { useMenu } from "../../../contexts/MenuContext";
import IMenuItemsList from "./interfaces/IMenuItemsList";
import { useTheme } from "styled-components";
import Logo from "../../Logo";
import { ContextMenu, Popover } from "devextreme-react";
import IOptionChangePosition from "./interfaces/IOptionChangePosition";
import EnumMsg from "../../../translate/enums/EnumMsg";
import Grid from "../../Grid";
import { useAuth } from "../../../contexts/AuthContext";

const Sidebar: FC<IProps> = (props) => {
	//#region Context

	const theme = useTheme();
	const { translate } = useTranslate();
	const { state: menuState, dispatch: menuDispatch } = useMenu();
	const {
		state: { user },
		dispatch: authDispatch,
	} = useAuth();

	//#endregion

	//#region Memo

	const defaultItems: IMenuItem[] = useMemo(() => {
		return routes
			.filter((x) => x.displayOnMenu)
			.map<IMenuItem>((x) => {
				const menuItem: IMenuItem = {
					name: x.name,
					path: x.path,
					icon: x.icon,
					menuGroup: x.menuGroup,
					flag: EnumFlagMenuItem.Padrao,
					subItems: x.subRoutes,
					renderParentRoute: !!x.component,
				};

				return menuItem;
			});
	}, []);

	const defaultGroups: EnumMenuGroup[] = useMemo(
		() =>
			defaultItems
				.map((x) => x.menuGroup || EnumMenuGroup.Outros)
				.reduce<EnumMenuGroup[]>((arr, curr) => (arr.indexOf(curr) === -1 ? [...arr, curr] : arr), []),
		[defaultItems]
	);

	const optionsToChangePosition: IOptionChangePosition[] = useMemo(() => {
		let valor: IOptionChangePosition[] = [
			{ text: translate(EnumMsg.MoverParaCima), value: "top" },
			{ text: translate(EnumMsg.MoverParaBaixo), value: "bottom" },
			{ text: translate(EnumMsg.MoverParaEsquerda), value: "left" },
			{ text: translate(EnumMsg.MoverParaDireita), value: "right" },
		];

		return valor.filter((x) => x.value !== menuState.position);
	}, [menuState.position, translate]);

	//#endregion

	//#region State

	const [searchValue, setSearchValue] = useState("");
	const [showingHiddenItems, setShowingHiddenItems] = useState<boolean>(false);
	const [haveHiddenItems, setHaveHiddenItems] = useState<boolean>(false);
	const [haveFavoriteItems, setHaveFavoriteItems] = useState<boolean>(false);
	const [items, setItems] = useState<IMenuItemsList>({ default: [], favorites: [], hidden: [] });
	const [positionOptionsVisible, setPositionOptionsVisible] = useState<boolean>(false);
	const [moreConfigVisible, setMoreConfigVisible] = useState<boolean>(false);

	//#endregion

	//#region Callback

	const handleItemAction = useCallback(
		(itemPath: string, actionType: KeyItemActionType) => {
			if (itemPath) {
				switch (actionType) {
					case "fav": {
						let payload = [...menuState.favorites];
						if (payload.indexOf(itemPath) >= 0) payload = payload.filter((x) => x !== itemPath);
						else payload = [...payload, itemPath];
						menuDispatch({ type: "SET_MENU_FAVORITES", payload });
						break;
					}
					case "hide": {
						let payload = [...menuState.hidden];
						if (payload.indexOf(itemPath) >= 0) payload = payload.filter((x) => x !== itemPath);
						else payload = [...payload, itemPath];
						menuDispatch({ type: "SET_MENU_HIDDEN", payload });
						break;
					}
				}
			}
		},
		[menuState.favorites, menuState.hidden, menuDispatch]
	);

	//#endregion

	//#region Effect

	useEffect(() => {
		document.addEventListener("click", function (e) {
			if (menuState.open) {
				const numverBreakWidth = parseInt(theme.breakpoints.md.replace("px", ""));
				if (window.outerWidth <= numverBreakWidth) {
					const targetEL = e.target as HTMLElement;
					if (targetEL.id !== "sidebar-menu") menuDispatch({ type: "SET_MENU_OPEN", payload: false });
				}
			}
		});
	}, [theme, menuDispatch, menuState.open]);

	useEffect(() => {
		setHaveFavoriteItems(menuState.favorites?.length > 0);
	}, [menuState.favorites]);

	useEffect(() => {
		setHaveHiddenItems(menuState.hidden?.length > 0);
	}, [menuState.hidden]);

	useEffect(() => {
		const applySearchFilter = (item: IMenuItem): boolean => {
			if (!searchValue || !searchValue.trim()?.length) return true;

			const parentName = translate(item.name).toLowerCase();
			const valueSearch = searchValue.trim().toLocaleLowerCase();

			const parentContains = parentName.indexOf(valueSearch) >= 0;
			if (parentContains) return true;

			if (item.subItems?.length) {
				return item.subItems.findIndex((si) => translate(si.name).toLowerCase().indexOf(valueSearch) >= 0) >= 0;
			} else return false;
		};

		const getDefault = () => {
			const retorno = defaultItems.filter((x) => menuState.hidden?.indexOf(x.path) === -1 && menuState.favorites?.indexOf(x.path) === -1);
			return (retorno || []).filter((x) => applySearchFilter(x));
		};

		const getFavorites = () => {
			let favorites = defaultItems.filter((x) => menuState.favorites?.indexOf(x.path) >= 0);
			if (!favorites?.length) return [];
			return favorites.map((x) => ({ ...x, flag: EnumFlagMenuItem.Favorito })).filter((x) => applySearchFilter(x));
		};

		const getHidden = () => {
			let hidden = defaultItems.filter((x) => menuState.hidden?.indexOf(x.path) >= 0);
			if (!hidden?.length) return [];
			return hidden.map((x) => ({ ...x, flag: EnumFlagMenuItem.Oculto })).filter((x) => applySearchFilter(x));
		};

		setItems({
			default: getDefault(),
			favorites: getFavorites(),
			hidden: getHidden(),
		});
	}, [defaultItems, menuState.favorites, menuState.hidden, searchValue, translate]);

	useEffect(() => {
		setShowingHiddenItems((value) => value && haveHiddenItems);
	}, [haveHiddenItems]);

	//#endregion

	const getBtnsConfigActions = (): ReactNode => (
		<>
			<S.ConfigActionButton
				icon={MdSettingsBackupRestore}
				onClick={() => {
					menuDispatch({ type: "SET_MENU_CONFIG", payload: { open: true, favorites: [], hidden: [], position: menuState.position } });
					setMoreConfigVisible(false);
				}}
				disabled={!menuState.favorites?.length && !menuState.hidden?.length}
			/>
			<S.ConfigActionButton
				icon={showingHiddenItems ? MdVisibility : MdVisibilityOff}
				onClick={() => {
					setShowingHiddenItems((value) => !value);
					setMoreConfigVisible(false);
				}}
				disabled={!haveHiddenItems}
			/>
			<S.ConfigActionButton
				id="sideBtnChangePosition"
				icon={MdOpenWith}
				onClick={() => {
					menuDispatch({ type: "SET_MENU_OPEN", payload: true });
					setMoreConfigVisible(false);
					setPositionOptionsVisible(true);
				}}
			/>
		</>
	);


	return (
		<S.Container id="sidebar-menu" position={menuState.position} isOpen={menuState.open}>
			{(menuState.position === "left" || menuState.position === "right") && (
				<>
					<Logo>
						<S.FixBtn
							fixed={menuState.open}
							menuPosition={menuState.position}
							onClick={() => menuDispatch({ type: "SET_MENU_OPEN", payload: !menuState.open })}
						>
							<MdOutlinePushPin size="20px" />
						</S.FixBtn>
					</Logo>
				</>
			)}



			<S.SearchContainer>
				<S.SearchField value={searchValue} onChange={(value) => setSearchValue(value)} />
				<S.SearchIconContainer>
					<MdSearch size="20" />
				</S.SearchIconContainer>
			</S.SearchContainer>

			<S.ItemsContainer>
				{!showingHiddenItems &&
					haveFavoriteItems &&
					items.favorites.map(({ icon, name, path, flag, subItems }) => (
						<SidebarItem
							key={path}
							path={path}
							icon={icon}
							text={name}
							flag={flag}
							subRoutes={subItems}
							handleAction={handleItemAction}
							sideBarPosition={menuState.position}
							sideBarCompactMode={!menuState.open}
							searchValue={searchValue}
						/>
					))}

				{!showingHiddenItems && haveFavoriteItems ? <S.Divider /> : ""}

				{defaultGroups.map((group, idx, arr) => {
					let routesOfGroup = (showingHiddenItems ? items.hidden : items.default).filter((x) => x.menuGroup === group);

					if (routesOfGroup?.length) {
						const items = routesOfGroup.map(({ icon, name, path, flag, subItems }) => (
							<SidebarItem
								key={path}
								path={path}
								icon={icon}
								text={name}
								flag={flag}
								subRoutes={subItems}
								handleAction={handleItemAction}
								sideBarPosition={menuState.position}
								sideBarCompactMode={!menuState.open}
								searchValue={searchValue}
							/>
						));

						if (idx < arr.length - 1) items.push(<S.Divider key={`side_divider_${group}`} />);

						return items;
					}

					return null;
				})}
			</S.ItemsContainer>

			{menuState.position === "top" || menuState.position === "bottom" ? (
				<>
					<S.ConfigActionButton id="sideBtnMoreConfig" icon={MdMoreVert} onClick={() => setMoreConfigVisible((value) => !value)} />
					<Popover target="#sideBtnMoreConfig" visible={moreConfigVisible} closeOnOutsideClick onHiding={() => setMoreConfigVisible(false)}>
						<Grid justify="space-evenly">{getBtnsConfigActions()}</Grid>
					</Popover>
				</>
			) : (
				<S.FooterActionsContainer>{getBtnsConfigActions()}</S.FooterActionsContainer>
			)}

			<ContextMenu
				target={menuState.position === "top" || menuState.position === "bottom" ? "#sideBtnMoreConfig" : "#sideBtnChangePosition"}
				visible={positionOptionsVisible}
				dataSource={optionsToChangePosition}
				closeOnOutsideClick
				onHiding={() => setPositionOptionsVisible(false)}
				onItemClick={({ itemData }) => {
					let position = (itemData as IOptionChangePosition).value;
					setPositionOptionsVisible(false);
					menuDispatch({ type: "SET_MENU_POSITION", payload: position });
				}}
			/>
		</S.Container>
	);
};

export default memo(Sidebar);
