namespace SMS.Contracts
{
    public  interface IValidationService
    {
        (bool, string) ValidateModle(object model);
    }
}
