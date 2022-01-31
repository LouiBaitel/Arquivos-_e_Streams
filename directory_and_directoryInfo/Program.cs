using static System.Console;
using System.IO;

//-------------------------------------------------------------------------------------------------------------
// CriarDiretoriosGlobo(); //Chama o método de criar diretórios
// CriarArquivo(); 


// var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
// var destino = Path.Combine(Environment.CurrentDirectory, "globo", "América do Sul", "Argentina", "brasil.txt"); //Deve-se informar o caminho e o nome do arquivo.

// MoverArquivo(origem, destino); //Chamamos o método com as variáveis contendo o caminho de origem e de destino do arquivo
// CopiarArquivo(origem, destino);
//-------------------------------------------------------------------------------------------------------------

var path = @"C:\Users\Loui\Desktop\Arquivos de estudo - trabalho\Bootcamp GFT Start #3 .NET\Códigos das aulas\Trabalhando com Arquivos e Streams em C#\directory_and_directoryInfo\globo"; //Informamos o caminho da variável path utilizada em directory_and_directoryInfo

// LerDiretorios(path);

LerArquivos(path);

WriteLine("Digite [enter] para finalizar");
ReadLine();

// -------------------------------------- Ler diretórios --------------------------------------------------------------
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
// -------------------------------------------------------------------------------------------------------------------


// ------------------------------------------------ Ler Arquivos ----------------------------------------------------

static void LerArquivos(string path)
{
    var arquivos = Directory.GetFiles(path, "*",  SearchOption.AllDirectories);

    foreach (var arquivo in arquivos)
    {
        var fileInfo = new FileInfo(arquivo);
        
        WriteLine($"[Nome]: {fileInfo.Name}");
        WriteLine($"[Tamanho]: {fileInfo.Length}");
        WriteLine($"[Ultimo Acesso]: {fileInfo.LastAccessTime}");
        WriteLine($"[Pasta]: {fileInfo.DirectoryName}");
        WriteLine("-------------------------------");

    }
}

//-------------------------------------------------------------------------------------------------------------------


static void CopiarArquivo(string pathOrigem, string pathDestino)
{
    File.Copy(pathOrigem, pathDestino); //Como o File.Copy(origem,destino) conseguimos copiar o arquivo para outro diretório
}


static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if(!File.Exists(pathOrigem)){
        WriteLine("Arquivo de origem não existe");
        return;
    }
    else if(File.Exists(pathDestino)){
        WriteLine("Arquivo já existente na pasta de destino");
        return;
    }
    else{
        WriteLine();
        return;
    }

    File.Move(pathOrigem, pathDestino); //O File.Move possibilita mover os arquivos entre dos diretórios
}


static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");

    if(!File.Exists(path))
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("População: 212,6 MM");
        sw.WriteLine("IDH: 0,765");
        sw.WriteLine("Dados atualizados em 30/01/2022");
    }
    else
    {
        WriteLine("Este arquivo de texto já existe!");
    }
   
}


static void CriarDiretoriosGlobo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "globo");

    if(!Directory.Exists(path)) //Com !Directory.Exists(path) verificamos se o caminho e nome indicado na variável path não existem (devido a !), e o diretório será criado somente se não existir.
    {
        var dirGlobo = Directory.CreateDirectory(path); //Cria o diretório conforme as informações passadas na variável patch
                                                        //A partir da var dirGlobo é possivel criar os subdiretórios

        var dirAmNorte  = dirGlobo.CreateSubdirectory("América do Norte"); //Utilizando a variável dirGlobo acompanhada de CreateSubdirectory para criação do subdiretório
                                                                           // É criado como uma variável de dirAmNorte para que seja possivel adicionar as informações dos países dentro deste subdiretório.
        var dirAmSul = dirGlobo.CreateSubdirectory("América do Sul");
        var dirAmCentral = dirGlobo.CreateSubdirectory("América Central");


        dirAmNorte.CreateSubdirectory("Estados Unidos");
        dirAmNorte.CreateSubdirectory("México");
        dirAmNorte.CreateSubdirectory("Canadá");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Venezuela");

        dirAmCentral.CreateSubdirectory("Panamá");
        dirAmCentral.CreateSubdirectory("Costa Rica");
    }
    else{
        WriteLine("! Esse diretório já existe !");
    }

}
