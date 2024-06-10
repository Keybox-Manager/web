using KeyboxWeb.Logic.Interfaces.Services;

namespace KeyboxWeb.Logic.Services;

public class CardService : ICardService
{
    public string CardTitle()
    {
        return "cardTitle";
    }

    public string CardDescription()
    {
        return "cardDescription";
    }
}