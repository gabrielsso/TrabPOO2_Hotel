public interface IQuarto
{
    public int Num_quarto { get; }
    public int Usou_tel { get; set; }
    public int Pediu_comida { get; set; }
    public string Tipo_quarto { get; }
    public float Diaria { get; set; }

    void pedir_comida();
    void usar_telefone();
    int pegar_serviço_comida_usado();
    int pegar_serviço_telefone_usado();
    void Reroll_Number();
    void reset_serviço();
}
