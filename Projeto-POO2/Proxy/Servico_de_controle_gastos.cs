using System;

public class Servico_de_controle_gastos : IControle
{
    float preco_comida = 25;
    float preco_tel = 10;

    public double Calcular_Gasto(Reservas reservas)
    {
        Clientes cli = reservas.cliente;
        IQuarto quarto = reservas.Get_Quarto();
        float diaria = quarto.Diaria;
        int quant_tel = quarto.pegar_serviço_telefone_usado();
        int quant_comida = quarto.pegar_serviço_comida_usado();
        int dias_total = reservas.dia_saida.Day - reservas.dia_entrada.Day;
        float preco_total_comida = preco_comida * quant_comida;
        float preco_total_tel = preco_tel * quant_tel;
        float diaria_total = diaria * dias_total;
        float soma = (preco_total_comida + preco_total_tel + diaria_total);
        double total = soma + (soma * 0.5);
        Demonstrar_Gastos(diaria_total, preco_total_comida, preco_total_tel);
        return total;
    }

    public void Demonstrar_Gastos(float diaria_total, float preco_total_comida, float preco_total_tel){
        Console.WriteLine("Forem gasto em serviço de comida: R${0}", preco_total_comida);
        Console.WriteLine("Forem gasto em serviço de telefone: R${0}", preco_total_tel);
        Console.WriteLine("O total da diaria é de: R${0}", diaria_total);
    }
}
