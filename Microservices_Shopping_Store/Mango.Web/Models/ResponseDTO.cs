namespace Mano.Services.Coupan.Model.DTO
{
    public class ResponsetDTO
    {
        public Object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}
