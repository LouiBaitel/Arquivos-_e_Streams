using System.IO; // Possibilita a manutenção de arquivos e streams
using static System.Console;


WriteLine("Digite o nome do arquivo que deseja criar: ");
var nome = ReadLine(); //Criou-se uma variável para receber o nome do arquivo pelo usuário
nome = LimparNome(nome); //O método limpar nome é puxado para fazer a alteração do caractere especial

var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");     //variável criada para indicar o caminho e a criação de um arquivo txt
                                                                         // O comando Path.Combine faz a combinação da criação do diretório + o arquivo
                                                                         // Environment.CurrentDirectory faz a criação do diretório onde a aplicação está rodando
                                                                         // Caso queira criar o diretório em outro caminho, basta Path.Combine(@"C:\\temp" , "Teste.txt")


CriarArquivo(path); //O método criará o arquivo conforme o nome informado pelo usuário


// File.Create(path);  // Cria o arquivo conforme a variável path


WriteLine("Digite enter para finalizar.");
ReadLine();


static string LimparNome(string nome)
{
    // Com o foreach percorremos a lista de caracteres inválidos
    foreach (var caractere in Path.GetInvalidFileNameChars())  // O Path.GetInva... Gera uma lista de caracteres inválidos para criação de arquivos
    {
        nome = nome.Replace(caractere, '-'); // Caso seja inserido um caractere inválido, será substituido pelo caractere padrão definido. O arquivo será criado.
    }
    return nome;
}

static void CriarArquivo(string path)
{
    //Utilizamos o try catch para tratamentos de erros
    try   
    {
        using var sw = File.CreateText(path); //O arquivo vai ser criado conforme a variável path. Cria-se uma variável para utilizar os métodos de criação de texto
                                      // Com o using as linhas de texto ecrita sao enviadas para o arquivo automáticamente

        sw.WriteLine("Esta é a linha 1 do arquivo"); //Escreve uma linha de texto no arquivo
        sw.WriteLine("Esta é a linha 2 do arquivo");
        sw.WriteLine("Esta é a linha 3 do arquivo"); 
    }
    // Caso o usuário digite um caractere especial e o arquivo nao seja criado, o comando abaixo será executado.
    catch 
    {
        WriteLine("O nome do arquivo está inválido!");
    }   
}


// sw.Flush(); //Encerra o metodo WriteLine e descarrega a informação no arquivo
               // Se a linha escrita possuir muita informação, é iteressante utilizar o flush apos cada linha
