using BMechanic.bmSessionProvider;
using BMechanic.V4Net;

namespace BMPL
{
    class BMSessionGear
    {
        private static bmSessionProvider sProvider;

        public static bmSessionProvider SessionProvider
        {
            get
            {
                return sProvider;
            }
        }

        public BMSessionGear()
        {
            //Инициализация провайдера сессий
            sProvider = new bmSessionProvider(bmVDaProvider.DaProvider);
        }
    }
}
