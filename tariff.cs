class Tariff
{
    private Tariffs _name;
    private double _costPerMinute;
    private double _balance;
    private string _number;

    private Services[] _services;
    private string[] _calls;

    public Tariff()
    {
        _name = Tariffs.simpleLife;
        _costPerMinute = 0f;
        _balance = 0f;
        _number = "0123456789";
        _services = new Services[] { Services.internet };
        _calls = new string[] { };
    }

    public Tariff(Tariffs name,
     double costPerMinute,
     double balance,
     string number,
     Services[] services
    )
    {
        _name = name;
        _costPerMinute = costPerMinute;
        _balance = balance;
        _number = number;
        _services = services;
        _calls = new string[] { };
    }

    public string toString()
    {
        return $"\nname: {_name}, \ncostPeMinute: {_costPerMinute}, \nbalance: {_balance}, \nnumber: {_number}, \nservices:{string.Join(", ", _services)}\n";
    }

    public string changeTariff(Tariffs newTariff)
    {
        _name = newTariff;
        return $"Тариф змінено, новий тариф {newTariff}";
    }

    public double addCall(double minutes, string callNumder)
    {
        _balance -= 10;
        _calls = _calls.Concat(new string[] { "Номер - " + callNumder + ", час " + minutes }).ToArray();
        return minutes * _costPerMinute;
    }

    public string addService(Services newServices)
    {   
        switch (newServices)
        {
            case Services.internet:
            _balance -= 15;break;
            case Services.sms:
            _balance -= 10;break;
            case Services.roaming:
            _balance -= 20;break;
        }

        _services = _services.Where(val => val != newServices).ToArray();
        _services = _services.Concat(new Services[] { newServices }).ToArray();
        return $"Додано послугу {newServices}";
    }

    public string removeService(Services newServices)
    {
        _services = _services.Where(val => val != newServices).ToArray();
        return $"Відключено послугу {newServices}";
    }

    public string replenishBalance(double addToBalance)
    {
        _balance += addToBalance;
        return $"Рахунок поповнено на {addToBalance}, поточний рахунок {_balance}";
    }

    public string getBalance()
    {
        return $"Поточний рахунок {_balance}";
    }

    public string getCalls()
    {
        return $"Історія ваших дзвінків {string.Join("\n", _calls)}";
    }

}


public enum Tariffs
{
    smartLife,
    freeLife,
    simpleLife,
    schoolLife
}
public enum Services
{
    roaming,
    internet,
    sms
}
