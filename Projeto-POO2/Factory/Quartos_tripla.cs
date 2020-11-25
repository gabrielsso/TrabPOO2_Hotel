using System;

public class Quartos_tripla : IQuarto
{
    private int _num_quarto;
    private float _diaria;
    private int _pediu_comida;
    private int _usado_tel;
    
    public Quartos_tripla(){
        Random rnd = new Random();
        _num_quarto = rnd.Next(500+1);
        _diaria = 120;
    }

    public string Tipo_quarto => "Tripla";

    public int Num_quarto{
        get { return _num_quarto; }
    }
    
    public int Usou_tel{
        get { return _usado_tel; }
        set {_usado_tel = value; }
    }
    public int Pediu_comida{
        get { return _pediu_comida; }
        set {_pediu_comida = value; }
    }
    public float Diaria{
        get { return _diaria; }
        set {_diaria = value; }
    }

    public void pedir_comida()
    {
        Console.WriteLine("\nO quarto {0} pediu comida.\n", _num_quarto);
        _pediu_comida ++;
    }
    public void usar_telefone()
    {
        Console.WriteLine("\nO quarto {0} usou telefone.\n", _num_quarto);
        _usado_tel ++;
    }

    public int pegar_serviço_comida_usado()
    {
        return _pediu_comida;
    }

    public int pegar_serviço_telefone_usado()
    {
        return _usado_tel;
    }

    public void Reroll_Number(){
        Random rnd = new Random();
        _num_quarto = rnd.Next(500+1);
    }

    public void reset_serviço(){
        _pediu_comida = 0;
        _usado_tel = 0;
    }
}
