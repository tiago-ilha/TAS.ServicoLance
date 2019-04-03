using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace TAS.SL.Api.ViewModels
{
    public class RegistrarLanceViewModel : Notifiable, IValidatable
    {
        public Guid IdAnuncio { get; set; }
        public decimal Valor { get; set; }

        public void Validate()
        {
            
        }
    }
}
