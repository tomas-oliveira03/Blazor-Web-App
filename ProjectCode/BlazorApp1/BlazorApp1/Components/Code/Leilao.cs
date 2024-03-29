public class Leilao{
    
    private int idLeilao;
    private string tamanhoArtigo;
    private DateTime dataUsoArtigo;
    private string nomeEquipaEventoArtigo;
    private string nomeArtigo;
    private string descricaoArtigo;
    private int numeroAutenticacaoArtigo;
    private string estadoArtigo;
    private string imagemArtigo;
    private string nomeLeilao;
    private double taxaMinimaIncrementoLeilao;
    private DateTime dataFinalizacaoLeilao;
    private double precoCompraAutomaticoLeilao;
    private double precoBaseLeilao;
    private int idCategoria;
    private long idVendedor;
    private string estadoLeilao;
    private List<Licitacao> licitacoes;

    public Leilao(){
        this.idLeilao = 0;
        this.tamanhoArtigo = "";
        this.dataUsoArtigo = DateTime.Now;
        this.nomeEquipaEventoArtigo = "";
        this.nomeArtigo = "";
        this.descricaoArtigo = "";
        this.numeroAutenticacaoArtigo = 0;
        this.estadoArtigo = "";
        this.imagemArtigo = "";
        this.nomeLeilao = "";
        this.taxaMinimaIncrementoLeilao = 0;
        this.dataFinalizacaoLeilao = DateTime.Now;
        this.precoCompraAutomaticoLeilao = 0;
        this.precoBaseLeilao = 0;
        this.idCategoria = 0;
        this.idVendedor = 0;
        this.estadoLeilao = "";
        this.licitacoes = new List<Licitacao>();
    }

    public Leilao(int idLeilao, string tamanho, DateTime data, string nomeEquipaEvento, string nomeArtigo, string descricao, int autenticacao, string estadoArtigo, string urlImagem, string nomeLeilao, double taxaMinIncremento, DateTime dataFinal, double precoCompraAutomatica, double precoBase, int idCategoria, int idVendor, string estadoLeilao){
        this.idLeilao = idLeilao;
        this.tamanhoArtigo = tamanho;
        this.dataUsoArtigo = data;
        this.nomeEquipaEventoArtigo = nomeEquipaEvento;
        this.nomeArtigo = nomeArtigo;
        this.descricaoArtigo = descricao;
        this.numeroAutenticacaoArtigo = autenticacao;
        this.estadoArtigo = estadoArtigo;
        this.imagemArtigo = urlImagem;
        this.nomeLeilao = nomeLeilao;
        this.taxaMinimaIncrementoLeilao = taxaMinIncremento;
        this.dataFinalizacaoLeilao = dataFinal;
        this.precoCompraAutomaticoLeilao = precoCompraAutomatica;
        this.precoBaseLeilao = precoBase;
        this.idCategoria = idCategoria;
        this.idVendedor = idVendor;
        this.estadoLeilao = estadoLeilao;
        this.licitacoes = new List<Licitacao>();  

    }

    public int GetIdLeilao(){
        return this.idLeilao;
    }

    public string GetTamanhoArtigo(){
        return this.tamanhoArtigo;
    }

    public DateTime GetDataUsoArtigo(){
        return this.dataUsoArtigo;
    }

    public DateOnly GetDataUsoArtigoDateOnly(){
        return DateOnly.FromDateTime(this.dataUsoArtigo);
    }

    public string GetNomeEquipaEventoArtigo(){
        return this.nomeEquipaEventoArtigo;
    }

    public string GetNomeArtigo(){
        return this.nomeArtigo;
    }

    public string GetDescricaoArtigo(){
        return this.descricaoArtigo;
    }

    public int GetNumeroAutenticacaoArtigo(){
        return this.numeroAutenticacaoArtigo;
    }

    public string GetEstadoArtigo(){
        return this.estadoArtigo;
    }

    public string GetImagemArtigo(){
        return this.imagemArtigo;
    }

    public string GetNomeLeilao(){
        return this.nomeLeilao;
    }

    public double GetTaxaMinimaIncrementoLeilao(){
        return this.taxaMinimaIncrementoLeilao;
    }

    public DateTime GetDataFinalizacaoLeilao(){
        return this.dataFinalizacaoLeilao;
    }

    public double GetPrecoCompraAutomaticoLeilao(){
        return this.precoCompraAutomaticoLeilao;
    }

    public double GetPrecoBaseLeilao(){
        return this.precoBaseLeilao;
    }

    public int GetIdCategoria(){
        return this.idCategoria;
    }

    public long GetIdVendedor(){
        return this.idVendedor;
    }

    public string GetEstadoLeilao(){
        return this.estadoLeilao;
    }

    public double GetHighestBid(){
        if (licitacoes == null || !licitacoes.Any()){
            return 0;
        }
        
        double highestBid = licitacoes.Max(licitacao => licitacao.GetValorLicitacao());
        return highestBid;
    }


    public long GetIdComprador(){
        double highestBid = this.GetHighestBid();

        if (licitacoes == null || !licitacoes.Any()){
            return 0;
        }
        
        for(int i = 0; i < this.licitacoes.Count; i++){
            if(this.licitacoes[i].GetValorLicitacao() == highestBid){
                return this.licitacoes[i].GetNIBComprador();
            }
        }
        return 0;
    }

    public string GetTimeLeft(){
        string zonaHorariaPortugalId = "GMT Standard Time";
        TimeZoneInfo zonaHorariaPortugal = TimeZoneInfo.FindSystemTimeZoneById(zonaHorariaPortugalId);
        DateTime agoraPortugal = TimeZoneInfo.ConvertTime(DateTime.UtcNow, zonaHorariaPortugal);
        TimeSpan diferenca = this.GetDataFinalizacaoLeilao() -  agoraPortugal;
        int totaldias = diferenca.Days;
        string res = totaldias.ToString() + " days, " + diferenca.Hours.ToString() + " hours, " + diferenca.Minutes.ToString() + " minutes, " + diferenca.Seconds.ToString() + " seconds";
        if(diferenca.Days < 0 || diferenca.Hours < 0 || diferenca.Minutes < 0 || diferenca.Seconds < 0){
            res = "Ended";
        }
        else if(this.GetEstadoLeilao() == "Vendido") res = "Ended";
        return res;
    }

    public double GetNextMinBid(){
        double preco = this.GetHighestBid();
        if(preco == 0) return this.GetPrecoBaseLeilao();

        double nextBid = this.GetHighestBid() + this.GetTaxaMinimaIncrementoLeilao();
        nextBid = Math.Round(nextBid, 2);
        if(nextBid > this.GetPrecoCompraAutomaticoLeilao()){
            nextBid = this.GetPrecoCompraAutomaticoLeilao();
        }
        return nextBid;
    }

    public void AddLicitacao(Licitacao licitacao){
        this.licitacoes.Add(licitacao);
    }

    public void SetLicitacoes(List<Licitacao> licitacoes){
        this.licitacoes = licitacoes;
    }

    public void verificarEstadoDoLeilao(){
        if(this.estadoLeilao == "A decorrer"){
            if(this.dataFinalizacaoLeilao < DateTime.Now){
                if(this.licitacoes.Count == 0) this.estadoLeilao = "Expirado";
                else this.estadoLeilao = "Vendido";
            }
        }
    }

    public long determinarVencedor(){
        if(this.estadoLeilao == "Vendido"){
            double highestBid = this.GetHighestBid();

            for(int i = 0; i < this.licitacoes.Count; i++){
                if(this.licitacoes[i].GetValorLicitacao() == highestBid){
                    return this.licitacoes[i].GetNIBComprador();
                }
            }
        }
        return 0;
    }


    public int GetStatusByUserWon(long idUser){
        if(GetIdComprador()==idUser) return 0; //WINNING
        else if(GetEstadoLeilao() == "Vendido") return 2; //LOST
        else return 1; //OUTBIDDED
    }

    public string GetStatusTextWon(int statusCode){
        if(statusCode==0) return "Winning";
        else if(statusCode==1) return "Outbidded";
        else return "Lost";
    }


    
    public int GetStatusByUserSold(){
        if(GetEstadoLeilao() == "Vendido") return 0; //WON
        else if(GetEstadoLeilao() == "A decorrer") return 1; //PENDING
        else return 2; //EXPIRED
    }

    public string GetStatusTextSold(int statusCode){
        if(statusCode==0) return "Sold";
        else if(statusCode==1) return "Pending";
        else return "Expired";
    }


    public override string ToString(){
        return $"Id: {GetIdLeilao()}, Leilao: {GetNomeLeilao()}, Tamanho: {GetTamanhoArtigo()}, Data: {GetDataUsoArtigo().ToString("dd/MM/yyyy HH:mm:ss")}, NomeEquipaEvento: {GetNomeEquipaEventoArtigo()}, NomeArtigo: {GetNomeArtigo()}, Descricao: {GetDescricaoArtigo()}, Autenticacao: {GetNumeroAutenticacaoArtigo()}, EstadoArtigo: {GetEstadoArtigo()}, UrlImagem: {GetImagemArtigo()}, TaxaMinIncremento: {GetTaxaMinimaIncrementoLeilao()}, DataFinal: {GetDataFinalizacaoLeilao().ToString("dd/MM/yyyy HH:mm:ss")}, PrecoCompraAutomatica: {GetPrecoCompraAutomaticoLeilao()}, PrecoBase: {GetPrecoBaseLeilao()}, IdCategoria: {GetIdCategoria()}, IdVendor: {GetIdVendedor()}, EstadoLeilao: {GetEstadoLeilao()}";
    }

    
}



    

