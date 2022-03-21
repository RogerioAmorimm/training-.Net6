import { FC, FormEvent, useEffect, useState } from "react";
import { useTheme } from "styled-components";
import Container from "../../components/Container";
import Grid from "../../components/Grid";
import { useAuth } from "../../contexts/AuthContext";
import { useTranslate } from "../../contexts/TranslateContext";
import { singIn } from "../../services/AuthApiService";
import { IProps } from "./interfaces/IProps";
import * as S from "./styles";
import { MdComputer, MdPolicy } from 'react-icons/md'
import EnumMsg from "../../translate/enums/EnumMsg";
import Input from "../../components/Input";
import Button from "../../components/Button";
import CheckBox from "../../components/CheckBox";
import { Link } from "react-router-dom";
import ChangeLanguage from "../../components/ChangeLanguage";
const LoginPage: FC<IProps> = (props) => {
    const theme = useTheme();
    const { translate } = useTranslate();
    const { dispatch: authDispatch } = useAuth();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {

        e.preventDefault();
        singIn({ email, password })
            .then((data) => {
                authDispatch({ type: "SIGN_IN", payload: { token: data.token, user: data.user, role: data.role } });
                props.routeNavigate("/dashboard");
            })
            .catch((err) => {
                alert(JSON.stringify(err));
            })
    };
    useEffect(() => {
        authDispatch({ type: "SIGN_OUT" })
    }, [authDispatch])

    return (
        <Container noPadding fullHeight>
            <S.GridContainer spacing={0} align="stretch">
                <S.LeftPanel item paper xs={12} md={8}>
                    <Container maxWidth="sm" fullHeight noPadding>
                        <Grid direction="column" spacing={3} justify="space-between" align="stretch" fullHeight>
                            <S.LeftPanelHeader>
                                <Grid spacing={3}>
                                    <Grid item>
                                        <S.IconContainer>
                                            <MdComputer size="25px" color="#FFF" />
                                        </S.IconContainer>
                                    </Grid>
                                    <Grid item>
                                        <h1>Request APP</h1>
                                    </Grid>
                                </Grid>
                            </S.LeftPanelHeader>

                            <S.LeftPanelMain>
                                <S.Form onSubmit={handleSubmit}>
                                    <Grid direction="column" spacing={3} align="stretch" justify="center" fullHeight>
                                        <Grid item>
                                            <p>{translate(EnumMsg.AcesseParaContinuar)}</p>
                                        </Grid>
                                        <Grid item>
                                            <Input
                                                required
                                                rounded="lg"
                                                mode="email"
                                                label={EnumMsg.Usuario}
                                                autoFocus
                                                name="email"
                                                value={email}
                                                onChange={(value) => setEmail(value || "")}
                                            />
                                        </Grid>
                                        <Grid item>
                                            <Input
                                                required
                                                rounded="lg"
                                                mode="password"
                                                label={EnumMsg.Senha}
                                                name="password"
                                                value={password}
                                                onChange={(value) => setPassword(value || "")}
                                            />
                                        </Grid>
                                        <Grid item>
                                            <Grid justify="space-between" align="center">
                                                <Grid item xs={12} md={8}>
                                                    <Grid align="center">
                                                        <Grid item>
                                                            <Button type="submit" rounded="lg">
                                                                {translate(EnumMsg.Acessar)}
                                                            </Button>
                                                            &nbsp;
                                                        </Grid>
                                                        <Grid item>
                                                            <CheckBox label={EnumMsg.LembrarDeMim} />
                                                        </Grid>
                                                    </Grid>
                                                </Grid>
                                                <Grid item xs={12} md={4}>
                                                    <Grid justify="flex-end">
                                                        <Link to="/">{translate(EnumMsg.EsqueceuSuaSenha)}</Link>
                                                    </Grid>
                                                </Grid>
                                            </Grid>
                                        </Grid>
                                    </Grid>
                                </S.Form>
                            </S.LeftPanelMain>

                            <S.LeftPanelFooter>
                                <Grid align="flex-end" justify="space-between" spacing={2} fullHeight>
                                    <Grid item xs={12} sm={8}>
                                        <Grid align="center">
                                            <MdPolicy size="25px" color={theme.palette.black.main} />
                                            &nbsp;
                                            <Link to="/">{translate(EnumMsg.TermosDeUsoPoliticaDePrivacidade)}</Link>
                                        </Grid>
                                    </Grid>
                                    <Grid item xs={12} sm={4}>
                                        <Grid justify="flex-end">
                                            <ChangeLanguage />
                                        </Grid>
                                    </Grid>
                                </Grid>
                            </S.LeftPanelFooter>
                        </Grid>
                    </Container>
                </S.LeftPanel>
                <Grid item xs={12} md={4}>
                    <S.RightPanel>
                        <S.RightPanelShadow>
                            <S.RightPanelText>{translate(EnumMsg.DescricaoDoSistema)}</S.RightPanelText>
                        </S.RightPanelShadow>
                    </S.RightPanel>
                </Grid>
            </S.GridContainer>
        </Container>
    )
}
export default LoginPage;
