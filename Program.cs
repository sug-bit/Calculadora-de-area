using System.Globalization;

    Console.WriteLine("Calculadora de área");
    Console.WriteLine("1 - Retângulo");
    Console.WriteLine("2 - Quadrado");
    Console.WriteLine("3 - Círculo");
    Console.WriteLine("4 - Triângulo");
    Console.Write("Escolha uma opção: ");

if (!int.TryParse(Console.ReadLine(), out int opcao))
    {
	    Console.WriteLine("Opção inválida.");
	    return;
}

    double LerMedida(string mensagem)
{
	Console.Write(mensagem);
	string? entrada = Console.ReadLine()?.Replace(',', '.');
	if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double medida) && medida > 0)
		return medida;

	throw new ArgumentException("Informe uma medida positiva válida.");
}

try
{
	double area = opcao switch
	{
		1 => LerMedida("Largura: ") * LerMedida("Altura: "),
		2 => Math.Pow(LerMedida("Lado: "), 2),
		3 => Math.PI * Math.Pow(LerMedida("Raio: "), 2),
		4 => LerMedida("Base: ") * LerMedida("Altura: ") / 2,
		_ => throw new ArgumentException("Opção inválida.")
	};

	Console.WriteLine($"Área: {area:F2}");
}
catch (ArgumentException erro)
{
	Console.WriteLine(erro.Message);
}
