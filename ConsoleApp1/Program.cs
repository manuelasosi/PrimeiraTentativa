using AppEscola.RegrasDeNegocio;

Aluno[] salaDeAula = new Aluno[350];

int cont = 1;
int posicao = 0;
byte opcao = 0;

while (opcao != 7)
{
    Console.Clear();
    Console.WriteLine("%%%%%%%%%%%%%%%%%%%% MENU %%%%%%%%%%%%%%%%%%%%%%");
    
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar o aluno");
    Console.WriteLine("2 - Listar os alunos");
    Console.WriteLine("3 - Consultar aluno por número de matrícula");
    Console.WriteLine("4 - Listar alunos aprovados");
    Console.WriteLine("5 - Listar alunos reprovados");
    Console.WriteLine("7 - Fechar o sistema");
    Console.Write("Opção N°............................");
    opcao = Convert.ToByte(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            CadastrarAlunos();
            break;
        case 2:
            ListarALunos();
            break;
        case 3:
            ConsultarAluno();
            break;
        case 4:
            AlunosAprovados();
            break;
        case 5:
            AlunosReprovados();
            break;
        case 7:
            Console.Clear();
            Console.Write("Deseja mesmo sair do sistema? S/N: ");
            string resp = Console.ReadLine();
            if (resp.ToUpper() == "N") opcao = 0;
            break;

        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("OPÇÃO INVÁLIDA");
            Console.ForegroundColor = ConsoleColor.White;

            break;

    }// fim do switch
}//Fim do laço principal

void CadastrarAlunos()
{
    int opc = 1;
    while (opc != 0)
    {
        if (cont < 350)
        {
            Aluno aluno = new Aluno();
            Console.Clear();
            Console.WriteLine("############### CADASTRAR ALUNO ################");
            Console.WriteLine();
            Console.WriteLine($"Número de inscrição................... {cont}");
            aluno.Id = cont;
            aluno.NumeroDeMatricula = cont * 1000;

            Console.Write("Nome...................  ");
            aluno.Nome = Console.ReadLine();
            Console.Write("Nota 1................... ");
            aluno.Nota1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota 2................... ");
            aluno.Nota2 = Convert.ToDouble(Console.ReadLine());

            salaDeAula[posicao] = aluno;
            cont++; posicao++;
            Console.Write("Deseja continuar cadastrando? S/N: ");
            string resp = Console.ReadLine();
            if (resp.ToUpper() == "N") opc = 0;

        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("################ VAGAS ESGOTADAS ################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}//Fim da função cadastrar alunos

// ############################## Função para listar alunos matriculados ########################
void ListarALunos()
{
    Console.Clear();
    for (int i = 0; i < cont - 1; i++)
    {
        Aluno aluno = salaDeAula[i];
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"ID.................{aluno.Id}");
        Console.WriteLine($"Matricula.................{aluno.NumeroDeMatricula}");
        Console.WriteLine($"Nome.................{aluno.Nome}");
        Console.WriteLine($"Nota1................{aluno.Nota1}");
        Console.WriteLine($"Nota2.................{aluno.Nota2}");
        Console.WriteLine($"Média..........{aluno.CalcularMedia()}");
        if (aluno.CalcularMedia() < 60) Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"Situação..........{aluno.MostrarSituacao()}");
        Console.ForegroundColor = ConsoleColor.White;

    }
    Console.ReadKey();
}
// ############################## Função consultar aluno por número de matrícula########################
void ConsultarAluno()
{
    int opc = 1;
    while (opc != 0)
    {


        Console.Write("Digite a Matricula do aluno.................");
        int matriculaV = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i <= matriculaV; i++)
        {
            Aluno aluno = salaDeAula[i];
            if (matriculaV > aluno.NumeroDeMatricula)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("@@@@@@@@@@@@@@@@@ ALUNO NÃO ENCONTRADO @@@@@@@@@@@@@@@@@@");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"ID.................{aluno.Id}");
                Console.WriteLine($"Matricula.................{aluno.NumeroDeMatricula}");
                Console.WriteLine($"Nome.................{aluno.Nome}");
                Console.WriteLine($"Nota1................{aluno.Nota1}");
                Console.WriteLine($"Nota2.................{aluno.Nota2}");
                Console.WriteLine($"Média..........{aluno.CalcularMedia()}");
                if (aluno.CalcularMedia() < 60) Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Situação..........{aluno.MostrarSituacao()}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Deseja continuar cadastrando? S/N: ");
                string resp = Console.ReadLine();
                if (resp.ToUpper() == "N") opc = 0;

                Console.ReadKey();
            }

        }

    }
}
// ############################## Função Listar alunos APROVADOS ########################
void AlunosAprovados()
{
    Console.Clear();
    for (int i = 0; i < cont - 1; i++)
    {

        Aluno aluno = salaDeAula[i];
        if (aluno.CalcularMedia() >= 60)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"ID.................{aluno.Id}");
            Console.WriteLine($"Matricula.................{aluno.NumeroDeMatricula}");
            Console.WriteLine($"Nome.................{aluno.Nome}");
            Console.WriteLine($"Nota1................{aluno.Nota1}");
            Console.WriteLine($"Nota2.................{aluno.Nota2}");
            Console.WriteLine($"Média..........{aluno.CalcularMedia()}");


        }

    }
    Console.ReadKey();
}

// ############################## Função Listar alunos REPROVADOS ########################
void AlunosReprovados()
{
    Console.Clear();
    for (int i = 0; i < cont - 1; i++)
    {

        Aluno aluno = salaDeAula[i];
        if (aluno.CalcularMedia() < 60)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"ID.................{aluno.Id}");
            Console.WriteLine($"Matricula.................{aluno.NumeroDeMatricula}");
            Console.WriteLine($"Nome.................{aluno.Nome}");
            Console.WriteLine($"Nota1................{aluno.Nota1}");
            Console.WriteLine($"Nota2.................{aluno.Nota2}");
            Console.WriteLine($"Média..........{aluno.CalcularMedia()}");

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    Console.ReadKey();

}