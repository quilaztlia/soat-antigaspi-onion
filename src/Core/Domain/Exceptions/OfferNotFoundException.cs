namespace Domain.Exceptions
{
    public sealed class OfferNotFoundException : NotFoundException
    {
        public OfferNotFoundException(Guid offerId)
            : base($"Offer {offerId} not found.")
        {
        }

    }
}