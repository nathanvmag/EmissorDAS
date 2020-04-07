using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Android.Util;
using Android.Graphics;
using Android.Media;

namespace EmissorApp.Droid
{
    [Service]
    class Servn : Service
    {
        Activity at;

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
        [return: GeneratedEnum]
        private Timer CheckTimer;
        int day, notday = 0;
            public void debugmyserv()
        {
            CheckTimer = new Timer(
                (o)=>{
                    DateTime dt = DateTime.Now;
                    Log.Debug("SERVICEE", "Work");

                    day = dt.Day;
                    if(day!=notday&& dt.Hour == 8)
                    {
                        notday = day;
                        Log.Debug("SERVICEE", "NOTIFICA AI TIO");
                        Notify(this, "Move Online", " Não esqueça de gerar seu imposto.", 0);
                        Notify(this, "Move Online", "Gerencie o pagamento de seus impostos direto de seu aplicativo em CONSULTA.", 3);
                        if(day<=22)
                        {
                            Notify(this, "Move Online", "Seu imposto vence dia 20 não esqueça de pagar.",1);
                        }
                    }
                   
                },null,0,20000
            
            );
        }
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            debugmyserv();
            return StartCommandResult.Sticky;
        }
        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
        public static void Notify(Service sr, string Title, string ContentText, int Value)
        {
            Intent intent = new Intent(sr, typeof(MainActivity));
            PendingIntent pendingIntent = PendingIntent.GetActivity(sr, Value, intent,
                                                                    PendingIntentFlags.UpdateCurrent);

            Notification.Builder builder = new Notification.Builder(sr)
        .SetContentTitle(Title)
        .SetContentText(ContentText)
        .SetSmallIcon(Resource.Drawable.logo).SetLargeIcon(BitmapFactory.DecodeResource(sr.ApplicationContext.Resources, Resource.Drawable.logo))
                                                .SetStyle(new Notification.BigTextStyle().BigText(ContentText))
                        .SetContentIntent(pendingIntent).SetPriority((int)Notification.PriorityHigh);


            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
                sr.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 8;
            notificationManager.Notify(Value+notificationId, notification);

        }

    }
}