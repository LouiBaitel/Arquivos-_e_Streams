using static System.Console;


var path = @"C:\Users\Loui\Desktop\Arquivos de estudo - trabalho\Bootcamp GFT Start #3 .NET\Códigos das aulas\Trabalhando com Arquivos e Streams em C#\directory_and_directoryInfo"; //Informamos o caminho da variável path utilizada em directory_and_directoryInfo

LerDiretorios(path);


WriteLine("Digite [enter] para finalizar");
ReadLine();

static void LerDiretorios(string path)
{

    if(Directory.Exists(path))
    {
        var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories); //Com o Directory.GetDirectories podemos fazer a busca dos diretórios, conforme:
                                                    // o path deve ser informado
                                                    // "*" significa que a busca será feita para todos os nomes de diretórios, caso deseje alguma restrição, deverá informar entre as aspas.
                                                    //SearchOption.AllDirectories significa que a busca será feita em todos os diretórios e subdiretórios existentes
                                                    //Este método retorna uma lista, que pode ser percorrida por um foreach

        foreach (var dir in diretorios)             //Cria-se um foreach para que seja possivel percorrer a lista de diretórios encontrada
        {
            var dirInfo = new DirectoryInfo(dir);   //A variável dirInfor é criada através de DirectoryInfo para que sera possivel verificar as informações sobre os diretórios encontrados
            WriteLine($"[Nome]: {dirInfo.Name}");   
            WriteLine($"[Raiz]: {dirInfo.Root}");

            if( dirInfo.Parent != null)
            {
                WriteLine($"[Pai]: {dirInfo.Parent.Name}");
            }
            else
            {
                WriteLine("[Pai]: Não existe");
            }

            WriteLine("-------------------------------");
        }
    } 
    else{
        WriteLine($"{path} não existe.");
    }                                                
}
