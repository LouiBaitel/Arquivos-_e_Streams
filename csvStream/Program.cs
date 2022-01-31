using static System.Console;

CriarCsv();

WriteLine("\n\n Pressione [ENTER] para finalizar");
ReadLine();


//------------------------------------- Método para criar CSV ------------------------------------

static void CriarCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory,
           "Saida");
    var pessoas = new List<Pessoa>()
    {
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 4488557,
            Nascimento = new DateOnly(year:1987, month:5, day:17)
        },
        new Pessoa()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 554822,
            Nascimento = new DateOnly(year:1965, month:4, day:7)
        },
        new Pessoa()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 4455821,
            Nascimento = new DateOnly(year:2003, month:12, day:25)
        },
        new Pessoa()
        {
            Nome = "Carla Moras",
            Email = "cms@gmail.com",
            Telefone = 7656392,
            Nascimento = new DateOnly(year:1998, month:6, day:3)
        }
    };

    var di = new DirectoryInfo(path);
    if(!di.Exists)
    {
        di.Create();
        path = Path.Combine(path, "usuarios.csv");
    }

    using var sw = new StreamWriter(path);
    sw.WriteLine("Nome, Email, Telefone, Nascimento");

    foreach (var pessoa in pessoas)
    {
        var linha = $"{pessoa.Nome}, {pessoa.Email}, {pessoa.Telefone}, {pessoa.Nascimento}";
        sw.WriteLine(linha);
    }
}

//------------------------------------------------------------------------------------------------


//------------------------------------ Método para ler csv ---------------------------------------

static void LerCsv()
{
    var path = Path.Combine(Environment.CurrentDirectory,
           "Entrada",
           "usuarios-exportacao.csv");


    if(File.Exists(path))
    {
        using var sr = new StreamReader(path);
        var cabecalho = sr.ReadLine()?.Split(',');  //Com o .Split informamos que o separador das informações será a vírgula (nesse caso)

        while(true)
        {
            var registro = sr.ReadLine()?.Split(',');
            if (registro == null) break;

            if(cabecalho.Length != registro.Length)
            {
                WriteLine("Arquivo fora dos padrões CSV.");
                break;
            }
            for (int i = 0; i < registro.Length; i++)
            {
                WriteLine($"{cabecalho?[i]}: {registro[i]}");
            }
        WriteLine("------------------");      
        }   
    }
    else
    {
        WriteLine($"O arquivo {path} não existe.");
    }

WriteLine("Pressione [ENTER] para sair.");
ReadLine();
}

//-------------------------------------------------------------------------------------------



//--------------------------------------- Classes -------------------------------------------

class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateOnly Nascimento { get; set; }
}

//-------------------------------------------------------------------------------------------