﻿using System;
using DIO.Series.Classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    InserirSerie();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:

                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();

        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetonaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
           Console.Write("Digite o id da serie: ");
           int indiceSerie = int.Parse(Console.ReadLine());

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
              Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i)); 
           }
           Console.Write("Digite o genero entre as opções acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());

           Console.Write("Digite Titulo da serie: ");
           string entradaTitulo = Console.ReadLine();

           Console.Write("Digite o Ano de inicio da serie: ");
           int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da serie: ");
           string entradaDescricao = Console.ReadLine();

           Serie atualizaSerie = new Serie (id: indiceSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opçoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

            

        }

        private static void ListarSeries()
        {
           Console.WriteLine("Listar series");
           var lista = repositorio.Lista();
           if (lista.Count == 0)
           {
               Console.WriteLine("Nenhuma serie cadastrada");
               return;
           }
           foreach (var serie in lista)
           {
               var excluido = serie.retornaExcluido();
               Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaID(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
           }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5 Visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
