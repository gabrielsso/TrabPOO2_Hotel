using System;

public class Controle_financeiro
{
    public void Pagamento(double valor, double reserva_preco){
        Console.WriteLine("\nO cliente pagou a reserva, com o valor de R${0:0.00}.", valor);
        if (reserva_preco > valor){
            Console.WriteLine("Não foi totalmente pago a reserva, está faltando R${0:0.00}\n",(reserva_preco - valor));
        }else if(valor > reserva_preco){
            Console.WriteLine("O preço pago foi acima do valor requerido, dando de troco R${0:0.00}\n",(valor - reserva_preco));
        }else{
            Console.WriteLine("O valor foi pago com sucesso.\n");
        }
    }        
}
