//using Data.Linq.Mapping.Seguridad;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Visualize.Controles.Metro
{
    public static class Dialogs
    {
        public static async void showMessage(string mensaje, string titulo,  MetroWindow metro)
        {
            await metro.ShowMessageAsync(titulo, mensaje);
        }
        public static async Task<MessageDialogResult> showQuestionMessage(string mensaje, string titulo, MetroWindow metro)
        {
            return await metro.ShowMessageAsync(titulo, mensaje, style: MessageDialogStyle.AffirmativeAndNegative);
        }
        public static async Task<MessageDialogResult> showQuestionMessage(string mensaje, string titulo,MessageDialogStyle style, MetroWindow metro)
        {
            return await metro.ShowMessageAsync(titulo, mensaje, style: style);
        }
        public static async void showException(Exception ex, string tit, MetroWindow metro)
        {
            await metro.ShowExceptionAsync(tit, ex);
        }
        public static async Task<LoginDialogData> showLogin(MetroWindow metro, string titulo, string mensaje)
        {
            return await metro.ShowLoginAsync(titulo, mensaje, new LoginDialogSettings() { AffirmativeButtonText="Iniciar", PasswordWatermark="Contraseña", UsernameWatermark="Usuario" }).ConfigureAwait(false);
        }
        public static async Task<ProgressDialogController> showProgress(string mensaje, string titulo, MetroWindow metro)
        {
            return await metro.ShowProgressAsync(titulo, mensaje);
        }
        //public static async Task<MahApps.Metro.Controls.Dialogs.SALoginDialogData> showLoginSA(MetroWindow metro, string titulo, string mensaje, List<Empresa> empresas)
        //{
        //    return await metro.ShowLoginAsync(titulo, mensaje,empresas.Select(x=>x as object).ToList(), new LoginDialogSettings() { AffirmativeButtonText = "Iniciar", PasswordWatermark = "Contraseña", UsernameWatermark = "Usuario", NegativeButtonText="Cancelar",NegativeButtonVisibility=Visibility.Visible }).ConfigureAwait(false);
        //}
        //public static async Task<MahApps.Metro.Controls.Dialogs.SALoginDialogData> showLoginSA(MetroWindow metro, string titulo, string mensaje, List<Empresa> empresas, string inicial)
        //{
        //    return await metro.ShowLoginAsync(titulo, mensaje, empresas.Select(x => x as object).ToList(), new LoginDialogSettings() { AffirmativeButtonText = "Iniciar", PasswordWatermark = "Contraseña", UsernameWatermark = "Usuario", NegativeButtonText = "Cancelar", NegativeButtonVisibility = Visibility.Visible, InitialUsername = inicial }).ConfigureAwait(false);
        //}
        
    }
}
