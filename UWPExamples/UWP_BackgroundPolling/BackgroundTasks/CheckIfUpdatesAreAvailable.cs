using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET

namespace BackgroundTasks
{
    //Articles de référence:
    //1. Création d'une tâche d'arrière-plan: https://msdn.microsoft.com/en-us/windows/uwp/launch-resume/create-and-register-an-outofproc-background-task
    //2. Configuration de celle-ci pour tourner toutes les 15 minutes: https://msdn.microsoft.com/en-us/windows/uwp/launch-resume/run-a-background-task-on-a-timer-
    //3. Affichage d'une notification toast: https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10/
    public sealed class CheckIfUpdatesAreAvailable : IBackgroundTask
    {
        BackgroundTaskDeferral _deferral;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();

            //1. envoyer requête HTTP au back-end pour vérifier si des mises à jour importantes sont disponibles. Pas illustré ici.
            //2. si c'est le cas, afficher une notification 
            ShowNotification();

            _deferral.Complete();
        }

        public void ShowNotification()
        {
            // https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10/;
            // In a real app, these would be initialized with actual data
            string title = "Smart City";
            string content = "Nouveaux travaux signalés!";
            string image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f1/France_road_sign_AK5.svg/200px-France_road_sign_AK5.svg.png";
            string logo = "ms-appdata:///Assets/Travaux.png";

            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
        {
            new AdaptiveText()
            {
                Text = title
            },

            new AdaptiveText()
            {
                Text = content
            },

            new AdaptiveImage()
            {
                Source = image
            }
        },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };


            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                //Actions = actions,

                // Arguments when the user taps body of toast
    //            Launch = new QueryString()
    //{
    //    { "action", "viewConversation" },
    //    { "conversationId", conversationId.ToString() }

    //}.ToString()
            };

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());
            toast.ExpirationTime = DateTime.Now.AddMinutes(2);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
