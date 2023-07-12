using System;
using System.Collections.Generic;

class Program {
    static List<Campeonato> campeonatos = new List<Campeonato>();
    static List<Equipe> equipes = new List<Equipe>();
    static List<Jogador> jogadores = new List<Jogador>();
    static List<Partida> partidas = new List<Partida>();

    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1. Criar novo registro");
            Console.WriteLine("2. Visualizar registros existentes");
            Console.WriteLine("3. Editar registro existente");
            Console.WriteLine("4. Deletar registro existente");
            Console.WriteLine("5. Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao)) {
                switch (opcao) {
                    case 1:
                        CriarNovoRegistro();
                        break;
                    case 2:
                        VisualizarRegistros();
                        break;
                    case 3:
                        EditarRegistro();
                        break;
                    case 4:
                        DeletarRegistro();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine();
        }
    }

    static void CriarNovoRegistro() {
        Console.WriteLine("Selecione o tipo de registro que deseja criar:");
        Console.WriteLine("1. Campeonato");
        Console.WriteLine("2. Equipe");
        Console.WriteLine("3. Jogador");
        Console.WriteLine("4. Partida");

        int tipoRegistro;
        if (int.TryParse(Console.ReadLine(), out tipoRegistro)) {
            switch (tipoRegistro) {
                case 1:
                    CriarCampeonato();
                    break;
                case 2:
                    CriarEquipe();
                    break;
                case 3:
                    CriarJogador();
                    break;
                case 4:
                    CriarPartida();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    static void CriarCampeonato() {
        Console.WriteLine("Digite o nome do campeonato:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite a data de início do campeonato:");
        DateTime dataInicio = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Digite a data de fim do campeonato:");
        DateTime dataFim = DateTime.Parse(Console.ReadLine());

        int idCampeonato = campeonatos.Count + 1;
        Campeonato novoCampeonato = new Campeonato(idCampeonato, nome, dataInicio, dataFim);
        campeonatos.Add(novoCampeonato);

        Console.WriteLine("Campeonato criado com sucesso.");
    }

    static void CriarEquipe() {
        Console.WriteLine("Digite o nome da equipe:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite a cidade da equipe:");
        string cidade = Console.ReadLine();

        int idEquipe = equipes.Count + 1;
        Equipe novaEquipe = new Equipe(idEquipe, nome, cidade);
        equipes.Add(novaEquipe);

        Console.WriteLine("Equipe criada com sucesso.");
    }

    static void CriarJogador() {
        Console.WriteLine("Digite o nome do jogador:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite a data de nascimento do jogador:");
        DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Digite a posição do jogador:");
        string posicao = Console.ReadLine();

        int idJogador = jogadores.Count + 1;
        Jogador novoJogador = new Jogador(idJogador, nome, dataNascimento, posicao);
        jogadores.Add(novoJogador);

        Console.WriteLine("Jogador criado com sucesso.");
    }

    static void CriarPartida() {
        Console.WriteLine("Selecione o campeonato da partida:");
        VisualizarCampeonatos();

        int idCampeonato;
        if (int.TryParse(Console.ReadLine(), out idCampeonato)) {
            if (ExisteCampeonato(idCampeonato)) {
                Console.WriteLine("Digite a data da partida:");
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite o local da partida:");
                string local = Console.ReadLine();

                int idPartida = partidas.Count + 1;
                Partida novaPartida = new Partida(idPartida, idCampeonato, data, local);
                partidas.Add(novaPartida);

                Console.WriteLine("Partida criada com sucesso.");
            }
            else {
                Console.WriteLine("Campeonato não encontrado.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void VisualizarRegistros() {
        Console.WriteLine("Selecione o tipo de registro que deseja visualizar:");
        Console.WriteLine("1. Campeonato");
        Console.WriteLine("2. Equipe");
        Console.WriteLine("3. Jogador");
        Console.WriteLine("4. Partida");

        int tipoRegistro;
        if (int.TryParse(Console.ReadLine(), out tipoRegistro)) {
            switch (tipoRegistro) {
                case 1:
                    VisualizarCampeonatos();
                    break;
                case 2:
                    VisualizarEquipes();
                    break;
                case 3:
                    VisualizarJogadores();
                    break;
                case 4:
                    VisualizarPartidas();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    static void VisualizarCampeonatos() {
        Console.WriteLine("Campeonatos:");
        foreach (var campeonato in campeonatos) {
            Console.WriteLine($"ID: {campeonato.IdCampeonato}, Nome: {campeonato.Nome}, Data de Início: {campeonato.DataInicio}, Data de Fim: {campeonato.DataFim}");
        }
    }

    static void VisualizarEquipes() {
        Console.WriteLine("Equipes:");
        foreach (var equipe in equipes) {
            Console.WriteLine($"ID: {equipe.IdEquipe}, Nome: {equipe.Nome}, Cidade: {equipe.Cidade}");
        }
    }

    static void VisualizarJogadores() {
        Console.WriteLine("Jogadores:");
        foreach (var jogador in jogadores) {
            Console.WriteLine($"ID: {jogador.IdJogador}, Nome: {jogador.Nome}, Data de Nascimento: {jogador.DataNascimento}, Posição: {jogador.Posicao}");
        }
    }

    static void VisualizarPartidas() {
        Console.WriteLine("Partidas:");
        foreach (var partida in partidas) {
            Console.WriteLine($"ID: {partida.IdPartida}, Campeonato: {ObterNomeCampeonato(partida.IdCampeonato)}, Data: {partida.Data}, Local: {partida.Local}");
        }
    }

    static void EditarRegistro() {
        Console.WriteLine("Selecione o tipo de registro que deseja editar:");
        Console.WriteLine("1. Campeonato");
        Console.WriteLine("2. Equipe");
        Console.WriteLine("3. Jogador");
        Console.WriteLine("4. Partida");

        int tipoRegistro;
        if (int.TryParse(Console.ReadLine(), out tipoRegistro)) {
            switch (tipoRegistro) {
                case 1:
                    EditarCampeonato();
                    break;
                case 2:
                    EditarEquipe();
                    break;
                case 3:
                    EditarJogador();
                    break;
                case 4:
                    EditarPartida();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    static void EditarCampeonato() {
        Console.WriteLine("Digite o ID do campeonato que deseja editar:");
        VisualizarCampeonatos();

        int idCampeonato;
        if (int.TryParse(Console.ReadLine(), out idCampeonato)) {
            Campeonato campeonato = campeonatos.Find(c => c.IdCampeonato == idCampeonato);
            if (campeonato != null) {
                Console.WriteLine("Digite o novo nome do campeonato:");
                campeonato.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova data de início do campeonato:");
                campeonato.DataInicio = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite a nova data de fim do campeonato:");
                campeonato.DataFim = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Campeonato editado com sucesso.");
            }
            else {
                Console.WriteLine("Campeonato não encontrado.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarEquipe() {
        Console.WriteLine("Digite o ID da equipe que deseja editar:");
        VisualizarEquipes();

        int idEquipe;
        if (int.TryParse(Console.ReadLine(), out idEquipe)) {
            Equipe equipe = equipes.Find(e => e.IdEquipe == idEquipe);
            if (equipe != null) {
                Console.WriteLine("Digite o novo nome da equipe:");
                equipe.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova cidade da equipe:");
                equipe.Cidade = Console.ReadLine();

                Console.WriteLine("Equipe editada com sucesso.");
            }
            else {
                Console.WriteLine("Equipe não encontrada.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarJogador() {
        Console.WriteLine("Digite o ID do jogador que deseja editar:");
        VisualizarJogadores();

        int idJogador;
        if (int.TryParse(Console.ReadLine(), out idJogador)) {
            Jogador jogador = jogadores.Find(j => j.IdJogador == idJogador);
            if (jogador != null) {
                Console.WriteLine("Digite o novo nome do jogador:");
                jogador.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova data de nascimento do jogador:");
                jogador.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Digite a nova posição do jogador:");
                jogador.Posicao = Console.ReadLine();

                Console.WriteLine("Jogador editado com sucesso.");
            }
            else {
                Console.WriteLine("Jogador não encontrado.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarPartida() {
        Console.WriteLine("Digite o ID da partida que deseja editar:");
        VisualizarPartidas();

        int idPartida;
        if (int.TryParse(Console.ReadLine(), out idPartida)) {
            Partida partida = partidas.Find(p => p.IdPartida == idPartida);
            if (partida != null) {
                Console.WriteLine("Digite o novo campeonato da partida:");
                VisualizarCampeonatos();
                int idCampeonato;
                if (int.TryParse(Console.ReadLine(), out idCampeonato)) {
                    if (ExisteCampeonato(idCampeonato)) {
                        partida.IdCampeonato = idCampeonato;

                        Console.WriteLine("Digite a nova data da partida:");
                        partida.Data = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o novo local da partida:");
                        partida.Local = Console.ReadLine();

                        Console.WriteLine("Partida editada com sucesso.");
                    }
                    else {
                        Console.WriteLine("Campeonato não encontrado.");
                    }
                }
                else {
                    Console.WriteLine("ID inválido. Tente novamente.");
                }
            }
            else {
                Console.WriteLine("Partida não encontrada.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void DeletarRegistro() {
        Console.WriteLine("Selecione o tipo de registro que deseja deletar:");
        Console.WriteLine("1. Campeonato");
        Console.WriteLine("2. Equipe");
        Console.WriteLine("3. Jogador");
        Console.WriteLine("4. Partida");

        int tipoRegistro;
        if (int.TryParse(Console.ReadLine(), out tipoRegistro)) {
            switch (tipoRegistro) {
                case 1:
                    DeletarCampeonato();
                    break;
                case 2:
                    DeletarEquipe();
                    break;
                case 3:
                    DeletarJogador();
                    break;
                case 4:
                    DeletarPartida();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
        else {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    static void DeletarCampeonato() {
        Console.WriteLine("Digite o ID do campeonato que deseja deletar:");
        VisualizarCampeonatos();

        int idCampeonato;
        if (int.TryParse(Console.ReadLine(), out idCampeonato)) {
            Campeonato campeonato = campeonatos.Find(c => c.IdCampeonato == idCampeonato);
            if (campeonato != null) {
                campeonatos.Remove(campeonato);
                Console.WriteLine("Campeonato deletado com sucesso.");
            }
            else {
                Console.WriteLine("Campeonato não encontrado.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void DeletarEquipe() {
        Console.WriteLine("Digite o ID da equipe que deseja deletar:");
        VisualizarEquipes();

        int idEquipe;
        if (int.TryParse(Console.ReadLine(), out idEquipe)) {
            Equipe equipe = equipes.Find(e => e.IdEquipe == idEquipe);
            if (equipe != null) {
                equipes.Remove(equipe);
                Console.WriteLine("Equipe deletada com sucesso.");
            }
            else {
                Console.WriteLine("Equipe não encontrada.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void DeletarJogador() {
        Console.WriteLine("Digite o ID do jogador que deseja deletar:");
        VisualizarJogadores();

        int idJogador;
        if (int.TryParse(Console.ReadLine(), out idJogador)) {
            Jogador jogador = jogadores.Find(j => j.IdJogador == idJogador);
            if (jogador != null) {
                jogadores.Remove(jogador);
                Console.WriteLine("Jogador deletado com sucesso.");
            }
            else {
                Console.WriteLine("Jogador não encontrado.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void DeletarPartida() {
        Console.WriteLine("Digite o ID da partida que deseja deletar:");
        VisualizarPartidas();

        int idPartida;
        if (int.TryParse(Console.ReadLine(), out idPartida)) {
            Partida partida = partidas.Find(p => p.IdPartida == idPartida);
            if (partida != null) {
                partidas.Remove(partida);
                Console.WriteLine("Partida deletada com sucesso.");
            }
            else {
                Console.WriteLine("Partida não encontrada.");
            }
        }
        else {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static bool ExisteCampeonato(int idCampeonato) {
        return campeonatos.Exists(c => c.IdCampeonato == idCampeonato);
    }

    static string ObterNomeCampeonato(int idCampeonato) {
        Campeonato campeonato = campeonatos.Find(c => c.IdCampeonato == idCampeonato);
        if (campeonato != null) {
            return campeonato.Nome;
        }
        return "Campeonato não encontrado";
    }
}

class Campeonato {
    public int IdCampeonato { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public Campeonato(int idCampeonato, string nome, DateTime dataInicio, DateTime dataFim) {
        IdCampeonato = idCampeonato;
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
}

class Equipe {
    public int IdEquipe { get; set; }
    public string Nome { get; set; }
    public string Cidade { get; set; }

    public Equipe(int idEquipe, string nome, string cidade) {
        IdEquipe = idEquipe;
        Nome = nome;
        Cidade = cidade;
    }
}

class Jogador {
    public int IdJogador { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Posicao { get; set; }

    public Jogador(int idJogador, string nome, DateTime dataNascimento, string posicao) {
        IdJogador = idJogador;
        Nome = nome;
        DataNascimento = dataNascimento;
        Posicao = posicao;
    }
}

class Partida {
    public int IdPartida { get; set; }
    public int IdCampeonato { get; set; }
    public DateTime Data { get; set; }
    public string Local { get; set; }

    public Partida(int idPartida, int idCampeonato, DateTime data, string local) {
        IdPartida = idPartida;
        IdCampeonato = idCampeonato;
        Data = data;
        Local = local;
    }
}
