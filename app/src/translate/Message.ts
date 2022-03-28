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
    [EnumMsg.NewTickets]: {
        enUS: "New Tickets",
        es: "Entradas nuevas",
        ptBR: "Novos ingressos",
    },
    [EnumMsg.Tickets]: {
        enUS: "Tickets",
        es: "Entradas",
        ptBR: "Ingressos",
    },
    [EnumMsg.Confirmar]: {
        enUS: "Confirm",
        es: "Confirmar",
        ptBR: "Confirmar",
    },
    [EnumMsg.Sucesso]: {
        enUS: "Success",
        es: "Éxito",
        ptBR: "Sucesso",
    },
    [EnumMsg.ErroInesperado]:
    {
        enUS: "Unexpected error",
        es: "Error inesperado",
        ptBR: "Erro inesperado",
    },
    [EnumMsg.Codigo]: {
        enUS: "Code",
        es: "Código",
        ptBR: "Código",
    },
    [EnumMsg.Descricao]: {
        enUS: "Description",
        es: "Descripción",
        ptBR: "Descrição",
    },
    [EnumMsg.ORegistroSeraExcluidoPermanentemente]: {
        enUS: "The record will be permanently deleted",
        es: "El registro se eliminará de forma permanente",
        ptBR: "O registro será excluído permanentemente",
    },
    [EnumMsg.Confirmacao]: {
        enUS: "Confirmation",
        es: "Confirmación",
        ptBR: "Confirmação",
    },
    [EnumMsg.Cancelar]: {
        enUS: "Cancel",
        es: "Cancelar",
        ptBR: "Cancelar",
    },
    [EnumMsg.Adicionar]: {
        enUS: "Add",
        es: "Agregar",
        ptBR: "Adicionar",
    },
    [EnumMsg.Voltar]: {
        enUS: "Return",
        es: "Regreso",
        ptBR: "Voltar",
    },
    [EnumMsg.CodigoInvalido]: {
        enUS: "Invalid code",
        es: "Código invalido",
        ptBR: "Código inválido",
    },
    [EnumMsg.DescricaoEhObrigatorio]:
    {
        enUS: "Description is required",
        es: "Se requiere la Descripción",
        ptBR: "Desrição é obrigatória",
    },
    [EnumMsg.ADescricaoDeveTerNoMinimoDoisCaracteres]:
    {
        enUS: "The description must be at least 2 characters long",
        es: "La descripción debe tener al menos 2 caracteres",
        ptBR: "A descrição deve ter no mínimo 2 caracteres",
    },
    [EnumMsg.ADescricaoDeveTerNoMaximoCemCaracteres]: {
        enUS: "The description must have a maximum of 100 characters",
        es: "La descripción debe tener un máximo de 100 caracteres",
        ptBR: "A descrição deve ter no máximo 100 caracteres"
    },
    [EnumMsg.UserName]: {
        enUS: "From",
        es: "Desde",
        ptBR: "A partir de"
    },
    [EnumMsg.UserNameEhObrigatorio]:
    {
        enUS: "UserName is required",
        es: "Se requiere nombre de usuario",
        ptBR: "Nome de usuário é obrigatório"
    },
    [EnumMsg.UserNameDeveTerNoMinimoDoisCaracteres]: {
        enUS: "The username must be at least 2 characters long",
        es: "El nombre de usuario debe tener al menos 2 caracteres",
        ptBR: "O nome de usuário deve ter pelo menos 2 caracteres",
    },

    [EnumMsg.UserNameDeveTerNoMaximoCemCaracteres]: {
        enUS: "The username must have a maximum of 16 characters",
        es: "El nombre de usuario debe tener un máximo de 16 caracteres.",
        ptBR: "O nome de usuário deve ter no máximo 16 caracteres"
    },
    [EnumMsg.Email]: {
        enUS: "Email",
        es: "Email",
        ptBR: "Email"
    },
    [EnumMsg.Roles]: {
        enUS: "Role",
        es: "Papel",
        ptBR: "Função"
    },
    [EnumMsg.Register]: {
        enUS: "Register",
        es: "Registrarse",
        ptBR: "Cadastro"
    },
    [EnumMsg.ReSenha]: {
        enUS: "Re Password",
        es: "Volver a contraseña",
        ptBR: "Re senha"
    },
    [EnumMsg.SenhaEhObrigatorio]: {
        enUS: "Password is required",
        es: "Se requiere contraseña",
        ptBR: "Senha é obrigatorio"
    },
    [EnumMsg.EmailEhObrigatorio]:
    {
        enUS: "Email is required",
        es: "Correo electronico es requerido",
        ptBR: "O e-mail é obrigatório"
    },
    [EnumMsg.RoleEhObrigatorio]: {
        enUS: "Role is required",
        es: "Se requiere rol",
        ptBR: "A função é obrigatória"
    },
    [EnumMsg.Topics]: {
        enUS: "Topic",
        es: "Tema",
        ptBR: "Tema"

    }
};

export default Messages;


