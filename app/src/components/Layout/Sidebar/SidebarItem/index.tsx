import { FC, memo, useEffect, useMemo, useRef, useState } from "react";
import ISidebarItemProps from "./interfaces/ISidebarItemProps";
import * as S from "./styles";
import { ContextMenu, Popover } from "devextreme-react";
import { useNavigate, useLocation } from "react-router-dom";
import { useTranslate } from "../../../../contexts/TranslateContext";
import IItemActionMenuDataSource from "./interfaces/IItemActionMenuDataSource";
import EnumMsg from "../../../../translate/enums/EnumMsg";
import EnumFlagMenuItem from "../enums/EnumFlagMenuItem";
import { MdMoreVert } from "react-icons/md";

const SidebarItem: FC<ISidebarItemProps> = ({
	path,
	text,
	icon: Icon,
	flag,
	handleAction,
	sideBarPosition,
	sideBarCompactMode,
	subRoutes,
	renderParentRoute,
	searchValue,
}) => {
	const navigate = useNavigate();
	const location = useLocation();
	const { translate } = useTranslate();

	const [showingSubItems, setShowingSubItems] = useState<boolean>(false);

	const menuDataSource: IItemActionMenuDataSource[] = useMemo(
		() => [
			{ text: translate(flag !== EnumFlagMenuItem.Favorito ? EnumMsg.Favorito : EnumMsg.Padrao), key: "fav" },
			{ text: translate(flag !== EnumFlagMenuItem.Oculto ? EnumMsg.Ocultar : EnumMsg.Padrao), key: "hide" },
		],
		[translate, flag]
	);

	const itemId = useMemo(() => `nav_item__${path.replaceAll("/", "")}`, [path]);

	const handleItemClick = (subPath?: string) => {
		if (subRoutes?.length) setShowingSubItems((value) => !value);

		if (subPath?.length) {
			navigate(path.concat("/").concat(subPath).replaceAll("//", "/"));
		} else {
			if (subRoutes?.length) {
				if (!renderParentRoute) return;
			}

			if (path && path.replaceAll("/", "")?.length) {
				navigate(path);
			}
		}
	};

	useEffect(() => {
		if (sideBarCompactMode) setShowingSubItems(false);
	}, [sideBarCompactMode]);

	useEffect(() => {
		if (subRoutes?.length && searchValue && searchValue.trim()?.length) {
			const valueSearch = searchValue.trim().toLocaleLowerCase();
			const containsSubItemSearch = subRoutes.findIndex((sr) => translate(sr.name).toLowerCase().indexOf(valueSearch) >= 0) >= 0;
			setShowingSubItems((value) => value || ((sideBarPosition === "left" || sideBarPosition === "right") && containsSubItemSearch));
		} else setShowingSubItems(false);
	}, [searchValue, subRoutes, sideBarPosition, translate]);

	const getSubItemsTemplate = () => {
		return (subRoutes || [])
			.filter((sr) => {
				if (!searchValue?.length) return true;
				const valueSearch = searchValue.trim().toLocaleLowerCase();
				return translate(sr.name).toLowerCase().indexOf(valueSearch) >= 0;
			})
			.map(({ name, subPath }) => {
				const subItemId = itemId.concat(`__${subPath.replaceAll("/", "")}`);
				return (
					<S.SidebarItem key={subItemId} id={subItemId} onClick={() => handleItemClick(subPath)} isSubItem sideBarPosition={sideBarPosition}>
						<S.SidebarItemText>{translate(name)}</S.SidebarItemText>
					</S.SidebarItem>
				);
			});
	};

	const actionsMenuRef = useRef<ContextMenu>(null);
	return (
		<S.Container>
			<S.SidebarItem
				id={itemId}
				onClick={() => handleItemClick()}
				active={location.pathname.startsWith(path)}
				containsSubItem={!!subRoutes?.length}
				showingSubItems={showingSubItems}
				sideBarPosition={sideBarPosition}
				sideBarCompactMode={sideBarCompactMode}
				title={translate(text)}
			>
				{Icon ? (
					<S.SidebarItemIconContainer>
						<Icon size="19" />
					</S.SidebarItemIconContainer>
				) : (
					<></>
				)}
				<S.SidebarItemText>{translate(text)}</S.SidebarItemText>
				<S.OptionsBtn
					onClick={(e) => {
						e.stopPropagation();
						actionsMenuRef.current?.instance.show();
					}}
				>
					<MdMoreVert />
				</S.OptionsBtn>
			</S.SidebarItem>

			{subRoutes?.length ? (
				sideBarPosition === "left" || sideBarPosition === "right" ? (
					<S.SubItemsContainer show={showingSubItems}>{getSubItemsTemplate()}</S.SubItemsContainer>
				) : (
					<Popover
						target={`#${itemId}`}
						visible={showingSubItems}
						position={sideBarPosition === "top" ? "bottom" : "top"}
						showEvent="dxclick"
						closeOnOutsideClick
						onHiding={() => setShowingSubItems(false)}
					>
						<S.SubItemsContainer show>{getSubItemsTemplate()}</S.SubItemsContainer>
					</Popover>
				)
			) : null}

			<ContextMenu
				ref={actionsMenuRef}
				dataSource={menuDataSource}
				target={`#${itemId}`}
				position={{ my: sideBarPosition, at: "right", of: `#${itemId}` }}
				onItemClick={({ itemData }) => {
					const action = (itemData as IItemActionMenuDataSource).key;
					handleAction(path, action);
				}}
			/>
		</S.Container>
	);
};

export default memo(SidebarItem);
