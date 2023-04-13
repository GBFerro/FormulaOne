using FormulaOne;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var basededados = mongo.GetDatabase("Formula1");
        var collection = basededados.GetCollection<BsonDocument>("Pilotos");
        var documents = collection.Find(new BsonDocument()).ToList();

        #region BuscarPiloto
        //Console.WriteLine("Informe o nome do piloto: ");
        //string n = Console.ReadLine();

        //var filtro = Builders<BsonDocument>.Filter.Regex("Driver", n);

        //var p = collection.Find(filtro).FirstOrDefault();

        //var piloto = BsonSerializer.Deserialize<Driver>(p);

        //Console.WriteLine(piloto.ToString());
        #endregion

        #region [C]riar
        //Console.WriteLine("Nome: ");
        //string name = Console.ReadLine();

        //Console.WriteLine("Abreviacao: ");
        //string a = Console.ReadLine();

        //Console.WriteLine("numero: ");
        //int num = int.Parse(Console.ReadLine());

        //Console.WriteLine("equipe: ");
        //string t = Console.ReadLine();

        //Console.WriteLine("pais: ");
        //string c = Console.ReadLine();

        //Console.WriteLine("data de nascimento: ");
        //string b = Console.ReadLine();

        //Driver driver = new(name, a, num, t, c, b);

        //Console.WriteLine(driver.ToString());

        //var dr = new BsonDocument
        //{
        //    {"Driver", driver.Name },
        //    {"Abbreviation", driver.Abbreviation  },
        //    {"No", driver.Number  },
        //    {"Team", driver.Team  },
        //    {"Country", driver.Country  },
        //    {"Date of Birth", driver.BirthDate  }
        //};

        //Console.WriteLine(dr);

        //collection.InsertOne(dr);
        #endregion

        Console.WriteLine("Informe o nome do piloto: ");
        string nome = Console.ReadLine();

        var plt = collection.Find(Builders<BsonDocument>.Filter.Regex("Driver", nome)).First();

        var drv = BsonSerializer.Deserialize<Driver>(plt);

        Console.WriteLine("Informe o novo numero: ");
        int number = int.Parse(Console.ReadLine());

        //collection.UpdateOne(Builders<BsonDocument>.Filter.Regex("Driver", nome), 
        //    Builders<BsonDocument>.Update.Set("No", number));
        var filtro = Builders<BsonDocument>.Filter.Regex("Driver", nome);
        var update = Builders<BsonDocument>.Update.Set("No", number);

        //collection.UpdateOne(filtro, update);
        collection.FindOneAndDelete(filtro);
    }
}