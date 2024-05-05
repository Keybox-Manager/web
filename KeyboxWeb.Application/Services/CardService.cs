using KeyboxWeb.Core.Interfaces.Services;

namespace KeyboxWeb.Application.Services;


public class CardService : ICardService {
    public string CardTitle() {
        return "cardTitle";
    }

    public string CardDescription() {
        return "cardDescription";
    }
}
