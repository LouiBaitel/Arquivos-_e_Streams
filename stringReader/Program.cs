using static System.Console;
using System.Text;


var sb = new StringBuilder(); //O StringBuilder cria o objeto

sb.AppendLine("Caracteres presentes na primeira linha"); //AppendLine cria linhas dentro do objeto StringBuilder
sb.AppendLine("Caracteres presentes na segunda linha");
sb.AppendLine("Caracteres presentes na terceira linha");

var sr = new StringReader(sb.ToString());  //Utilizamos o StringReader para ler as informações do objeto criado

// var texto = sr.ReadToEnd(); //Ideal para textos pequenos

var buffer = new char[10]; //Aqui definimos qual a quantidade máxima de caracteres que podem ser lidos por vez

//------------------------------------------------------------------------------
// var pos = sr.Read(buffer); //Indicamos a leitura conforme a variável buffer

// WriteLine($"{string.Join("",buffer)}"); //o string.Join é utilizado para unir os arrays novamente
// ReadLine();
//------------------------------------------------------------------------------

var tamanho = 0;


//---------------------------- Segunda forma -----------------------------------

do{
    WriteLine(sr.ReadLine());

} while( sr.Peek() >= 0); //o Peek consome o próximo caractere a ser consumido em forma de bit

//------------------------------------------------------------------------------


//---------------------------- Primeira forma ----------------------------------
do
{
    buffer = new char[10]; //Garantimos que não ficara nenhum caractere para tras, limpando sempre o buffer
    tamanho = sr.Read(buffer); //Aqui é feita a leitura dos caracteres, nesse caso, no máximo 10
    WriteLine(string.Join("", buffer)); //O string.Join vem para juntas os blocos de 10 caracteres
    
} while( tamanho >= buffer.Length); //todas essas condições acontecerão apenas enquanto o tamaho for menor que o tamanho total do buffer
//------------------------------------------------------------------------------


WriteLine("Digite [enter] para finalizar.");
ReadLine();