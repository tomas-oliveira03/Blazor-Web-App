using DataLibrary;
using System.Data.SqlClient;
using System.Drawing;

public class DatabaseQueries{

    private readonly IConfiguration _config;
    private readonly ISqlDataAccess _data;

    
    public DatabaseQueries(IConfiguration config, ISqlDataAccess data){
        _config = config;
        _data = data;
    }

    public async Task<long> GetLoginStatus(string email, string password){

        string sql = "SELECT NIB FROM Utilizador WHERE Email = @email AND PalavraPasse = @password";

        var parameters = new { email, password};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        long id = 0;
        if (connectionString != null){
            id = await _data.ExecuteQuery<long>(sql, parameters, connectionString);
        }
        return id;
    }

    public async Task<string> GetNomeCategoria(int idCategoria){

        string sql = "SELECT Nome FROM Categoria WHERE IdCategoria = @idCategoria";

        var parameters = new { idCategoria };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        string nome = "";
        if (connectionString != null){
            nome = await _data.ExecuteQuery<string>(sql, parameters, connectionString);
        }
        return nome;
    }


    public async Task<string> GetAddress(Leilao leilao){

        double idComprador = leilao.GetIdComprador();

        string sql = "SELECT Morada FROM Utilizador WHERE NIB = @idComprador";

        var parameters = new { idComprador };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        string nome = "";
        if (connectionString != null){
            nome = await _data.ExecuteQuery<string>(sql, parameters, connectionString);
        }
        return nome;
    }

    public async Task<bool> GetAccountStatus(long idUser){

        string sql = "SELECT Status FROM Utilizador WHERE NIB = @idUser";

        var parameters = new { idUser };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        byte available = 1;
        if (connectionString != null){
            available = await _data.ExecuteQuery<byte>(sql, parameters, connectionString);
        }
        return available==0;
    }

    public async void updateAccountStatus(long idUser, byte estado){

        DateTime dataLicitacao = DateTime.Now;
        string sql = "UPDATE Utilizador SET Status = @estado WHERE NIB = @idUser";

        var parameters = new {estado, idUser};

        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        if (connectionString != null)
        {
            await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        } 

    }


    public async Task<string> GetNameUser(long idUser){

        string sql = "SELECT CONCAT(PrimeiroNome, ' ', UltimoNome) FROM Utilizador WHERE NIB = @idUser";

        var parameters = new { idUser };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        string nome = "";
        if (connectionString != null){
            nome = await _data.ExecuteQuery<string>(sql, parameters, connectionString);
        }
        return nome;
    }

    public async Task<bool> GetUser(long idUser){

        string sql = "SELECT NumeroTelemovel FROM Utilizador WHERE NIB = @idUser";

        var parameters = new { idUser };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        int id = 0;
        if (connectionString != null){
            id = await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        }
        return id!=0;
    }



    public async Task<List<Leilao>> GetAllAuctions(){

        string sql = "SELECT * FROM ArtigoLeilao";

        var parameters = new {};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null)
        {
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }


        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));
        }

        return leiloes;
    }

    public async Task<List<Categoria>> GetAllCategories(){

        string sql = "SELECT * FROM Categoria ORDER BY IdCategoria";

        var parameters = new {};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Categoria> leiloes = new List<Categoria>();
        if (connectionString != null)
        {
            leiloes = await _data.ExecuteQueryList<Categoria>(sql, parameters, connectionString);
        }

        return leiloes;
    }






    public async Task<Leilao?> GetAuctionById(int id){

        string sql = "SELECT * FROM ArtigoLeilao WHERE idLeilao = @id";

        var parameters = new {id};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null)
        {
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }

        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));
        }
        
        if(leiloes.Count == 1) return leiloes[0];

        return null;
    }


    public async Task<List<Licitacao>> GetAllBids(int idLeilao){

        string sql = "SELECT * FROM Licitacao WHERE IdLeilao = @idLeilao";

        var parameters = new {idLeilao};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Licitacao> bids = new List<Licitacao>();
        if (connectionString != null){
            bids = await _data.ExecuteQueryList<Licitacao>(sql, parameters, connectionString);
        }

        return bids;
    }



//////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////

    //PARA A PAGINA AUCTIONS
    public async Task<List<Leilao>> GetAllAuctionsWithoutUser(long idUser, int idCategoria){
        string sql;
        object parameters;
        if(idCategoria == 0){
            sql = "SELECT * FROM ArtigoLeilao WHERE IdVendedor != @idUser AND EstadoLeilao = 'A decorrer'";
            parameters = new {idUser}; 
        } 
        else{
            sql = "SELECT * FROM ArtigoLeilao WHERE IdVendedor != @idUser AND EstadoLeilao = 'A decorrer' AND IdCategoria=@idCategoria";
            parameters = new {idUser, idCategoria};
        }

        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null){
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }

        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));
        }

        return leiloes;
    }


    //PARA A PAGINA MYAUCTIONS
    public async Task<List<Leilao>> GetAllAuctionsOfUser(long idUser){

        string sql = "SELECT * FROM ArtigoLeilao WHERE IdVendedor = @idUser";

        var parameters = new {idUser};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null){
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }

        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));
        }

        return leiloes;

    }


    public async Task<List<Leilao>> GetAllAuctionsWonByUser(long idUser){

        string sql = "SELECT * FROM ArtigoLeilao WHERE EstadoLeilao = 'Vendido'";

        var parameters = new {};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null){
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }


        List<Leilao> leiloesWon = new List<Leilao>();
        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));

            if(leilao.GetIdComprador()==idUser) leiloesWon.Add(leilao);
        }
        

        return leiloesWon;

    }





    public async Task<List<Leilao>> GetAllAuctionsBided(long idUser){

        string sql = " SELECT * FROM ArtigoLeilao WHERE IdLeilao IN (SELECT DISTINCT IdLeilao FROM Licitacao WHERE NIBComprador = @idUser)";
        
        
        var parameters = new {idUser};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        List<Leilao> leiloes = new List<Leilao>();
        if (connectionString != null){
            leiloes = await _data.ExecuteQueryList<Leilao>(sql, parameters, connectionString);
        }

        List<Leilao> leiloesBided = new List<Leilao>();
        foreach (Leilao leilao in leiloes){
            leilao.SetLicitacoes(await GetAllBids(leilao.GetIdLeilao()));

            if(!(leilao.GetEstadoLeilao()=="Vendido" && leilao.GetIdComprador()==idUser)) leiloesBided.Add(leilao);
        }

        return leiloesBided;
    }


//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////







    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // USER QUERIES //////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public async Task<int> RegisterUser(string firstName, string lastName, string email, string password, string address, string phoneNumber, string bin){

        byte status = 1;
        string sql = "INSERT INTO Utilizador (PrimeiroNome, UltimoNome, Email, PalavraPasse, Morada, NumeroTelemovel, NIB, Status) "+ 
                "VALUES (@PrimeiroNome, @UltimoNome, @Email, @PalavraPasse, @Morada, @NumeroTelemovel, @NIB, @Status)";

        var parameters = new
        {
            @PrimeiroNome = firstName,
            @UltimoNome = lastName,
            @Email = email,
            @PalavraPasse = password,
            @Morada = address,
            @NumeroTelemovel = phoneNumber,
            @NIB = bin,
            @Status = status
        };

        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        if (connectionString != null)
        {
            await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        } 

        return 1;
    }

    public async Task<bool> isThereNIB(string nib){
        string sql = "SELECT NIB FROM Utilizador WHERE NIB = @nib";

        var parameters = new { @nib = Convert.ToInt64(nib) };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        long id = 0;
        if (connectionString != null)
        {
            id = await _data.ExecuteQuery<long>(sql, parameters, connectionString);
        }
        return id!=0;
    }

    public async Task<bool> isThereEmail(string email){
        string sql = "SELECT Email FROM Utilizador WHERE Email = @email";

        var parameters = new { @email = email };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        string resultEmail = string.Empty;
        if (connectionString != null)
        {
            resultEmail = await _data.ExecuteQuery<string>(sql, parameters, connectionString);
        }
        return !string.IsNullOrEmpty(resultEmail);
    }

    public async Task<bool> isTherePhoneNumber(string phoneNumber){
        string sql = "SELECT NumeroTelemovel FROM Utilizador WHERE NumeroTelemovel = @phoneNumber";

        var parameters = new { @phoneNumber = Convert.ToInt64(phoneNumber) };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        long id = 0;
        if (connectionString != null)
        {
            id = await _data.ExecuteQuery<long>(sql, parameters, connectionString);
        }
        return id!=0;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // ITEM QUERIES //////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////

    public async Task<int> AddItem(string nomeLeilao, string imagem, string precoBaseLeilao, string nomeArtigo, string numeroAutenticacaoArtigo, string precoCompraAutomaticoLeilao, string nomeEquipaEventoArtigo, string tamanhoArtigo, string taxaMinimaIncrementoLeilao, string descricaoArtigo, string estadoArtigo, string dataUsoArtigo, string dataFinalizacaoLeilao, long idVendedor, int idCategoria){

    string estadoLeilao = "A decorrer";

    string sql = "INSERT INTO ArtigoLeilao (NomeLeilao, ImagemArtigo, PrecoBaseLeilao, NomeArtigo, NumeroAutenticacaoArtigo, PrecoCompraAutomaticoLeilao, NomeEquipaEventoArtigo, TamanhoArtigo, TaxaMinimaIncrementoLeilao, DescricaoArtigo, EstadoArtigo, DataUsoArtigo, DataFinalizacaoLeilao, IdCategoria, IdVendedor, EstadoLeilao)" + 
                "VALUES (@NomeLeilao, @ImagemArtigo, @PrecoBaseLeilao, @NomeArtigo, @NumeroAutenticacaoArtigo, @PrecoCompraAutomaticoLeilao, @NomeEquipaEventoArtigo, @TamanhoArtigo, @TaxaMinimaIncrementoLeilao, @DescricaoArtigo, @EstadoArtigo, @DataUsoArtigo, @DataFinalizacaoLeilao, @IdCategoria, @IdVendedor, @EstadoLeilao)";

    var parameters = new
    {
        @NomeLeilao = nomeLeilao,
        @ImagemArtigo = imagem,
        @PrecoBaseLeilao = precoBaseLeilao,
        @NomeArtigo = nomeArtigo,
        @NumeroAutenticacaoArtigo = numeroAutenticacaoArtigo,
        @PrecoCompraAutomaticoLeilao = precoCompraAutomaticoLeilao,
        @NomeEquipaEventoArtigo = nomeEquipaEventoArtigo,
        @TamanhoArtigo = tamanhoArtigo,
        @TaxaMinimaIncrementoLeilao = taxaMinimaIncrementoLeilao,
        @DescricaoArtigo = descricaoArtigo,
        @EstadoArtigo = estadoArtigo,
        @DataUsoArtigo = dataUsoArtigo,
        @DataFinalizacaoLeilao = dataFinalizacaoLeilao,
        @IdCategoria = idCategoria,
        @IdVendedor = idVendedor,
        @EstadoLeilao = estadoLeilao
    };

    string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

    if (connectionString != null)
    {
        await _data.ExecuteQuery<int>(sql, parameters, connectionString);
    } 

    return 1;
    }





    public async Task<int> addBid(double valorLicitacao, long nibComprador, int idLeilao, double maxBid){

        DateTime dataLicitacao = DateTime.Now;
        string sql = "INSERT INTO Licitacao (ValorLicitacao, NIBComprador, IdLeilao, DataLicitacao) "+ 
                "VALUES (@ValorLicitacao, @NIBComprador, @IdLeilao, @DataLicitacao)";

        var parameters = new
        {
            @ValorLicitacao = valorLicitacao,
            @NIBComprador = nibComprador,
            @IdLeilao = idLeilao,
            @DataLicitacao = dataLicitacao
        };

        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        if (connectionString != null)
        {
            await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        } 


        if(maxBid == valorLicitacao) updateEstadoLeilao(idLeilao, "Vendido");

        return 1;
    }



    public async void updateEstadoLeilao(int idLeilao, string estadoLeilao){

        DateTime dataLicitacao = DateTime.Now;
        string sql = "UPDATE ArtigoLeilao SET EstadoLeilao = @estadoLeilao WHERE IdLeilao = @idLeilao";

        var parameters = new {idLeilao, estadoLeilao};

        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        if (connectionString != null)
        {
            await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        } 

    }





    public async Task<int> GetNumeroLeilao(){

        string sql = "SELECT COUNT(*) FROM ArtigoLeilao";

        var parameters = new {};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        int total = 0;
        if (connectionString != null){
            total = await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        }
        return total+1;
    }


    public async Task<bool> isThereAuthNumber(string num){
        string sql = "SELECT NumeroAutenticacaoArtigo FROM ArtigoLeilao WHERE NumeroAutenticacaoArtigo = @num";

        var parameters = new { @num = num };
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        string resultNum = string.Empty;
        if (connectionString != null)
        {
            resultNum = await _data.ExecuteQuery<string>(sql, parameters, connectionString);
        }
        return !string.IsNullOrEmpty(resultNum);
    }

    public async Task<bool> GetAuthenticationNumber(string authenticationNumber){

        string sql = "SELECT NumeroAutenticacaoValido FROM NumeroAutenticacaoValido WHERE NumeroAutenticacaoValido = @authenticationNumber";

        var parameters = new {@authenticationNumber = authenticationNumber};
        string connectionString = _config.GetConnectionString("DefaultConnection") ?? string.Empty;

        int id = 0;
        if (connectionString != null){
            id = await _data.ExecuteQuery<int>(sql, parameters, connectionString);
        }
        return id!=0;
    }



}