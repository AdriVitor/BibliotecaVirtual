using Livraria.Data;
using Livros.Models;

namespace Cadastro 
{
    public class cadastro{

    public static void Menu(){
            Console.Clear();

            System.Console.WriteLine("Olá, Seja Bem-Vindo(a) a Biblioteca Virtual");
            System.Console.WriteLine("");
            System.Console.WriteLine("1 - LISTAR TODOS OS LIVROS");
            System.Console.WriteLine("2 - LISTAR APENAS UM LIVRO");
            System.Console.WriteLine("3 - CADASTRAR UM LIVRO");
            System.Console.WriteLine("4 - ATUALIZAR UM LIVRO");
            System.Console.WriteLine("5 - DELETAR UM LIVRO");
            System.Console.WriteLine("0 - SAIR DA BIBLIOTECA");
            System.Console.WriteLine("");
            System.Console.Write("Escolha uma opção: ");

            try{
                var opcao = int.Parse(Console.ReadLine());

                switch(opcao){
                    case 1: ReadBooks(); break;
                    case 2: ReadOneBook(); break;
                    case 3: RegisterBook(); break;
                    case 4: UpdateBook(); break;
                    case 5: RemoveBook(); break;
                    case 0: Environment.Exit(0); break;
                    default: Menu(); break;
                }
            }catch(Exception){
                System.Console.WriteLine("Escolha uma opção válida");
                Console.ReadKey();
            }
        }
    public static void ReadOneBook(){
        Console.Clear();

        try{
            System.Console.Write("Digite o ID do livro: ");
            var id = int.Parse(Console.ReadLine());

            using(var context = new DataContext()){
                var book = context.livros.Where(x => x.Id == id);

                System.Console.WriteLine("LIVRO");
                System.Console.WriteLine("-------------");
                foreach(var item in book){
                    System.Console.WriteLine($"#ID: {item.Id}");
                    System.Console.WriteLine($"Título: {item.Titulo}");
                    System.Console.WriteLine($"Gênero: {item.Genero}");
                    System.Console.WriteLine($"Data de Lançamento: {(item.Dt_Lancamento).ToString("dd/MM/yyyy")}");
                }
            }
            System.Console.WriteLine("Deseja voltar para o Menu? ");
            System.Console.WriteLine("1 - SIM | 0 - NÃO");
            var escolha = int.Parse(Console.ReadLine());

            switch(escolha){
                case 1: Menu();; break;
                case 0: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }catch(Exception){
            System.Console.WriteLine("Escolha um ID válido");
            Console.ReadKey();
        }
    }

    public static void ReadBooks(){
        Console.Clear();

        try{
        using(var context = new DataContext()){
            var book = context.livros;

            System.Console.WriteLine("LIVROS");
            System.Console.WriteLine("-------------");    
            foreach(var item in book){
                System.Console.WriteLine($"#ID: {item.Id}");
                System.Console.WriteLine($"Título: {item.Titulo}");
                System.Console.WriteLine($"Gênero: {item.Genero}");
                System.Console.WriteLine($"Data de Lançamento: {(item.Dt_Lancamento).ToString("dd/MM/yyyy")}");
                System.Console.WriteLine("");
            }

            System.Console.WriteLine("Deseja voltar para o Menu? ");
            System.Console.WriteLine("1 - SIM | 0 - NÃO");
            var escolha = int.Parse(Console.ReadLine());

            switch(escolha){
                case 1: Menu();; break;
                case 0: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }
            }catch(Exception){
                System.Console.WriteLine("Escolha um ID válido");
                Console.ReadKey();
            }
        }

    public static void RegisterBook(){
        Console.Clear();

        try{
            using(var context = new DataContext()){
                System.Console.WriteLine("CADASTRO DE LIVROS");
                System.Console.WriteLine("-------------------");

                System.Console.Write("Digite o título do livro: ");
                string titulo = Console.ReadLine();

                System.Console.Write("Digite o gênero do livro: ");
                string genero = Console.ReadLine();

                System.Console.Write("Digite a data de lançamento do livro: ");
                DateTime data = DateTime.Parse(Console.ReadLine());

                var book = new livro{Titulo = titulo,
                                    Genero = genero,
                                    Dt_Lancamento = data};

                context.livros.Add(book);
                context.SaveChanges();                    

                System.Console.WriteLine("Livro Cadastrado");
                System.Console.WriteLine("--------------------");
                System.Console.WriteLine("");

                System.Console.WriteLine($"#ID: {book.Id}");
                System.Console.WriteLine($"Título: {book.Titulo}");
                System.Console.WriteLine($"Gênero: {book.Genero}");
                System.Console.WriteLine($"Data de Lançamento: {book.Dt_Lancamento.ToString("dd-MM-yyyy")}");

                System.Console.WriteLine("Deseja voltar para o Menu? ");
                System.Console.WriteLine("1 - SIM | 0 - NÃO");
                var escolha = int.Parse(Console.ReadLine());

                switch(escolha){
                    case 1: Menu();; break;
                    case 0: Environment.Exit(0); break;
                    default: Menu(); break;
                }
        }
        }
            catch(Exception){
            System.Console.WriteLine("Erro na Aplicação");
            Console.ReadKey();
        }
    }
        public static void UpdateBook(){
            Console.Clear();

            try{
                using(var context = new DataContext()){
                    System.Console.WriteLine("ALTERAÇÃO DE CADASTRO DE LIVROS");
                    System.Console.WriteLine("----------------------------------");
                    System.Console.WriteLine("");

                    System.Console.Write("Digite o ID do livro: ");
                    var id = int.Parse(Console.ReadLine());

                    var Liv = context.livros.FirstOrDefault(x=>x.Id == id);

                    System.Console.WriteLine($"Título: {Liv.Titulo}");
                    System.Console.WriteLine($"Gênero: {Liv.Genero}");
                    System.Console.WriteLine($"Data de Lançamento: {Liv.Dt_Lancamento.ToString("dd-MM-yyyy")}");

                    System.Console.WriteLine("");

                    System.Console.Write("Novo Título: ");
                    string titulo = Console.ReadLine();

                    System.Console.Write("Novo Gênero: ");
                    string genero = Console.ReadLine();

                    System.Console.Write("Nova data de lançamento: ");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    Liv.Titulo = titulo;
                    Liv.Genero = genero;
                    Liv.Dt_Lancamento = data;

                    context.Update(Liv);
                    context.SaveChanges();

                    Console.Clear();
                    System.Console.WriteLine("LIVRO ATUALIZADO");
                    System.Console.WriteLine("-----------------");

                    System.Console.WriteLine("");
                    System.Console.WriteLine($"#ID: {Liv.Id}");
                    System.Console.WriteLine($"Título: {Liv.Titulo}");
                    System.Console.WriteLine($"Gênero: {Liv.Genero}");
                    System.Console.WriteLine($"Data de Lançamento: {Liv.Dt_Lancamento.ToString("dd-MM-yyyy")}");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("Deseja voltar para o Menu? ");
                    System.Console.WriteLine("1 - SIM | 0 - NÃO");
                    var escolha = int.Parse(Console.ReadLine());

                    switch(escolha){
                        case 1: Menu();; break;
                        case 0: Environment.Exit(0); break;
                        default: Menu(); break;
                    }
                }
            }
            catch(Exception){
                System.Console.WriteLine("Escolha um ID válido");
                Console.ReadKey();
            }
        }

        public static void RemoveBook(){
            Console.Clear();

            try{
            using(var context = new DataContext()){
                System.Console.WriteLine("EXCLUIR LIVRO");
                System.Console.WriteLine("--------------");
                System.Console.WriteLine("");

                System.Console.Write("Digite o ID do livro: ");
                var id = int.Parse(Console.ReadLine());
                var book = context.livros.FirstOrDefault(x=>x.Id == id);

                Console.Clear();
                System.Console.WriteLine("LIVRO");
                System.Console.WriteLine("--------------");
                System.Console.WriteLine($"Título: {book.Titulo}");
                System.Console.WriteLine($"Gênero: {book.Genero}");
                System.Console.WriteLine($"Data de Lançamento: {book.Dt_Lancamento}");
                System.Console.WriteLine("");
                System.Console.WriteLine("Deseja excluir o livro? ");
                System.Console.WriteLine("1 - SIM | 2 - NÃO");
                var escolha = int.Parse(Console.ReadLine());

                switch(escolha){
                    case 1: context.Remove(book);
                            context.SaveChanges();
                            break;
                    case 2: Menu(); break;
                    default: Menu(); break;
                }

                System.Console.WriteLine("Deseja voltar para o Menu? ");
                System.Console.WriteLine("1 - SIM | 0 - NÃO");
                var escolha2 = int.Parse(Console.ReadLine());

                switch(escolha2){
                    case 1: Menu();; break;
                    case 0: Environment.Exit(0); break;
                    default: Menu(); break;
                }
            }
            }
            catch(Exception){
                System.Console.WriteLine("Erro na aplicação");
                Console.ReadKey();
            }
        }
    

    }
}