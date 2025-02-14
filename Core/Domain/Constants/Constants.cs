namespace PruebaBackend.Core.Domain.Constants
{
    public record Constants
    {
        public record Status
        {
            public static readonly string Disabled = "Disabled";
            public static readonly string Enabled = "Enabled";
            public static readonly string Available = "Available";
            public static readonly string Reserved = "Reserved";
            public static readonly string Occupied = "Occupied";
            public static readonly string Unavailable = "Unavailable";
            public static readonly string Confirmed = "Confirmed";
            public static readonly string Pending = "Pending";
            public static readonly string Cancelled = "Cancelled";
        }
        public record Messages
        {
            public static readonly string NotValidAgency = "La agencia proporcionada no es válida.";
            public static readonly string ErrorSaveAgency = "Error al guardar la agencia en la base de datos.";
            public static readonly string InternalErrorSavReservation = "Error interno al guardar la agencia.";

            public static readonly string NotValidHotel = "El hotel proporcionado no es válido.";
            public static readonly string ErrorSaveHotel = "Error al guardar el hotel en la base de datos.";
            public static readonly string InternalErrorSavHotel = "Error interno al guardar el hotel.";

            public static readonly string NotValidTraveler = "El viajero proporcionado no es válido.";
            public static readonly string ErrorSaveTravel = "Error al guardar el viajero en la base de datos.";
            public static readonly string InternalErrorSavTravel = "Error interno al guardar el viajero.";

            public static readonly string NotExistsHotel = "El hotel no existe.";
            public static readonly string ErrorUpdateHotel = "Error al actualizar el hotel en la base de datos.";
            public static readonly string InternalErrorUpdHotel = "Error interno al actualizar el hotel.";

            public static readonly string NotValidPreferHotel = "El hotel proporcionado no es válido.";
            public static readonly string ErrorSavePreferHotel = "Error al guardar el hotel en la lista de preferidos en la base de datos.";
            public static readonly string InternalErrorSavPreferHotel = "Error interno al guardar el hotel en la lista de preferidos.";

            public static readonly string NotValidRoom = "La Habitación no es válida.";
            public static readonly string ErrorSaveRoom = "Error al guardar la habitación de hotel en la base de datos.";
            public static readonly string InternalErrorSavRoom = "Error interno al guardar la habitación de hotel.";

            public static readonly string NotExistsRoom = "La habitación no existe.";
            public static readonly string ErrorUpdateRoom = "Error al actualizar la habitación en la base de datos.";
            public static readonly string InternalErrorUpdRoom = "Error interno al actualizar la habitación.";

            public static readonly string NotValidStatusHotel = "El Estado del hotel no es valido.";
            public static readonly string ErrorUpdateStatusHotel = "Error al actualizar el estado del hotel en la base de datos.";
            public static readonly string InternalErrorUpdStatusHotel = "Error interno al actualizar el estado del hotel.";

            public static readonly string NotValidReservation = "La reservación no es válida.";
            public static readonly string NotValidContactEmergencyReservation = "Contacto de emergencia no válido.";
            public static readonly string ErrorSaveReservation = "Error al guardar la reservación en la base de datos.";
            public static readonly string InternalErrorSavAgency = "Error interno al guardar la reservación.";
        }
    }
}
