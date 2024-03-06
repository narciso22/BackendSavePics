using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class UserDataHelper
    {
        public static User GetUserData(User usuario)
        {
            return new User
            {
                UserName = usuario.UserName,
                ApellidoP = usuario.ApellidoP,
                ApellidoM = usuario.ApellidoM
            };
        }

        public static void AsignarValoresActualizar(User request, User usuarioExistente)
        {
            usuarioExistente.UserName = request.UserName;
            usuarioExistente.ApellidoP = request.ApellidoP;
            usuarioExistente.ApellidoM = request.ApellidoM;
        }
        public static User ObtenerUsuario(SrvTrContext dbContext, string UserName) =>
            dbContext.Users.SingleOrDefault(u => u.UserName == UserName);
    
    }
}
