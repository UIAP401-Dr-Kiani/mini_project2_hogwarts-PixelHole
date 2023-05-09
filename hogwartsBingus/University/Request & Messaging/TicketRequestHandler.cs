using System;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;

namespace hogwartsBingus.DataStorage
{
    public static class TicketRequestHandler
    {
        public static void RequestTicket(TicketRequest request)
        {
            try
            {
                Dumbledore.Instance.AddTicketRequest(request);
            }
            catch (TicketAlreadyRequestedException e)
            {
                throw e;
            }
        }
    }
}