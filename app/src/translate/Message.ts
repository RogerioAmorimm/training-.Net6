import EnumMsg from "./enums/EnumMsg";
import IMessageValue from "./interfaces/IMessageValue";

const Messages: { [k in EnumMsg]: IMessageValue } = {
    [EnumMsg.AcesseParaContinuar]: {
        enUS: "Login to continue",
        ptBR: "Acesse para continuar",
        es: "Iniciar sesión para continuar"
    },
    [EnumMsg.Acessar]:
    {
        enUS: "Access",
        ptBR: "Acessar",
        es: "Acessar"
    },
    [EnumMsg.EmailError]:
    {
        enUS: "Invalid email",
        ptBR: "Email inválido",
        es: "Email inválido"
    },
    [EnumMsg.MaxLengthField]:
    {
        enUS: "Maximum character size is",
        ptBR: "Tamanho máximo de caracteres é:",
        es: "El tamaño máximo de caracteres es:"
    },
    [EnumMsg.MinLengthField]:
    {
        enUS: "Minimum character size is:",
        ptBR: "Tamanho mínimo de caracteres é:",
        es: "El tamaño mínimo de los caracteres es:"
    },
    [EnumMsg.CompareField]:
    {
        enUS: "Confirmation different from the original value",
        ptBR: "Confirmação diferente do valor original",
        es: "Confirmación diferente del valor original"
    },
    [EnumMsg.RequiredField]:
    {
        enUS: "Required field",
        ptBR: "Campo obrigatório",
        es: "Campo obligatorio"
    },
    [EnumMsg.Usuario]: {
        enUS: "User",
        es: "Usuario",
        ptBR: "Usuário",
    },
    [EnumMsg.Senha]: {
        enUS: "Password",
        es: "Contraseña",
        ptBR: "Senha",
    },
    [EnumMsg.LembrarDeMim]: {
        enUS: "Remember me",
        es: "Acordarse de mi",
        ptBR: "Lembrar de mim",
    },
    [EnumMsg.EsqueceuSuaSenha]: {
        enUS: "Forgot your password?",
        es: "¿Olvidaste tu contraseña?",
        ptBR: "Esqueceu sua senha?",
    },
    [EnumMsg.TermosDeUsoPoliticaDePrivacidade]: {
        enUS: "TERMS OF USE - PRIVACY POLICY",
        es: "TÉRMINOS DE USO - POLÍTICA DE PRIVACIDAD",
        ptBR: "TERMOS DE USO - POLÍTICA DE PRIVACIDADE",
    },
    [EnumMsg.DescricaoDoSistema]: {
        enUS: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa accusamus tenetur rerum perferendis quae repellat a quos recusandae quam. Laboriosam alias corporis adipisci, nobis voluptate numquam veritatis mollitia eaque cupiditate.",
        es: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa accusamus tenetur rerum perferendis quae repellat a quos recusandae quam. Laboriosam alias corporis adipisci, nobis voluptate numquam veritatis mollitia eaque cupiditate.",
        ptBR: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa accusamus tenetur rerum perferendis quae repellat a quos recusandae quam. Laboriosam alias corporis adipisci, nobis voluptate numquam veritatis mollitia eaque cupiditate.",
    },
    [EnumMsg.Dashboard]: {
        enUS: "Dashboard",
        es: "Dashboard",
        ptBR: "Dashboard",
    },
    [EnumMsg.Favorito]: {
        enUS: "Favorite",
        es: "Favorito",
        ptBR: "Favorito",
    },
    [EnumMsg.Padrao]: {
        enUS: "Default",
        es: "Predeterminado",
        ptBR: "Padrão",
    },
    [EnumMsg.Ocultar]: {
        enUS: "Hide",
        es: "Esconder",
        ptBR: "Ocultar",
    },
    [EnumMsg.MoverParaCima]: {
        enUS: "Move up",
        es: "Muévete a la arriba",
        ptBR: "Mover para cima",
    },
    [EnumMsg.MoverParaBaixo]: {
        enUS: "Move down",
        es: "Muévete a la abajo",
        ptBR: "Mover para baixo",
    },
    [EnumMsg.MoverParaDireita]: {
        enUS: "Move right",
		es: "Muévete a la derecha",
		ptBR: "Mover para direita",
    },
    [EnumMsg.MoverParaEsquerda]: {
        enUS: "Move left",
		es: "Muévete a la Izquierda",
		ptBR: "Mover para esquerda",
    },
    [EnumMsg.Pesquisar]: {
		enUS: "Search",
		es: "Buscar",
		ptBR: "Pesquisar",
	},
    [EnumMsg.NewTickets]:{
        enUS: "New Tickets",
		es: "Entradas nuevas",
		ptBR: "Novos ingressos",
    },
    [EnumMsg.Tickets]:{
        enUS: "Tickets",
		es: "Entradas",
		ptBR: "Ingressos",
    },
    
};

export default Messages;


