using CsvHelper.Configuration.Attributes;
public class Livro
{
    //[Name("titulo")]    //Com essa propriedade, podemos dar nomes diferentes aos objetos do método e o cabeçalho da tabela
                        //Caso o arquivo .csv não tenha cabeçalho, é possivel indicar como [Index(0)], [Index(1)] e etc.
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    //[CultureInfo("pt-BR")]
    public decimal Preco { get; set; }
    //[Format("dd/MM/yyyy")]
    public DateOnly Lancamento { get; set; }
}