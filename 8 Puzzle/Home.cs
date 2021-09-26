using _8_Puzzle.Menu;
using _8_Puzzle.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle
{
    public partial class eightpuzzle : Form
    {
        Button[,] _boardInitial;
        Button[,] _boardGoal;
        Button[,] _boardResult;

        int[] _pieceBlankInitial;
        int[] _pieceBlankGoal;
        int[] _pieceBlankResult;

        string[] _cboxAlgorithms;

        int[,] _matInitial;
        int[,] _matGoal;

        bool _scrambled;

        int[] row = new int[] { 1, 0, -1, 0 };
        int[] col = new int[] { 0, -1, 0, 1 };

        public Button[,] BoardInitial { get => _boardInitial; set => _boardInitial = value; }
        public Button[,] BoardGoal { get => _boardGoal; set => _boardGoal = value; }
        public Button[,] BoardResult { get => _boardResult; set => _boardResult = value; }
        public string[] CboxAlgorithms { get => _cboxAlgorithms; set => _cboxAlgorithms = value; }
        public int[,] MatInitial { get => _matInitial; set => _matInitial = value; }
        public int[,] MatGoal { get => _matGoal; set => _matGoal = value; }
        public int[] PieceBlankInitial { get => _pieceBlankInitial; set => _pieceBlankInitial = value; }
        public int[] PieceBlankGoal { get => _pieceBlankGoal; set => _pieceBlankGoal = value; }
        public int[] PieceBlankResult { get => _pieceBlankResult; set => _pieceBlankResult = value; }
        public bool Scrambled { get => _scrambled; set => _scrambled = value; }

        public eightpuzzle()
        {
            InitializeComponent();

            //Define a posição do branco
            PieceBlankInitial = new int[] { 1, 0 };
            PieceBlankGoal = new int[] { 2, 2 };

            //Cria Estados iniciais sugestivo/pré definido
            MatInitial =new int[Constants.N, Constants.N] {
                { 1, 2, 3 },
                { 0, 4, 6 },
                { 7, 5, 8 }
            };

            MatGoal = new int[Constants.N, Constants.N] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
             };

            //Cria os tabuleiros 
            BoardInitial = new Button[Constants.N, Constants.N] { 
                { btnPieceInitial_0, btnPieceInitial_1, btnPieceInitial_2 },
                { btnPieceInitial_3, btnPieceInitial_4, btnPieceInitial_5 },
                { btnPieceInitial_6, btnPieceInitial_7, btnPieceInitial_8 } };

            BoardGoal = new Button[Constants.N, Constants.N] { 
                { btnPieceGoal_0, btnPieceGoal_1, btnPieceGoal_2 }, 
                { btnPieceGoal_3, btnPieceGoal_4, btnPieceGoal_5 }, 
                { btnPieceGoal_6, btnPieceGoal_7, btnPieceGoal_8 } };

            BoardResult = new Button[Constants.N, Constants.N] {
                { btnResult_0, btnResult_1, btnResult_2 },
                { btnResult_3, btnResult_4, btnResult_5 },
                { btnResult_6, btnResult_7, btnResult_8 } };
            
            //Cria combo box de algoritmo
            CboxAlgorithms = new string[] { "A*", "BestFirst", "BranchAndBond"};
            
            //Embaralhado ?
            Scrambled = false;
        }

        //Click movimentação btn state final
        private void btnPieceGoal_0_Click(object sender, EventArgs e)
        {swapView(0, 0);}
        private void btnPieceGoal_1_Click(object sender, EventArgs e)
        { swapView(0, 1);}

        private void btnPieceGoal_2_Click(object sender, EventArgs e)
        { swapView(0, 2); }

        private void btnPieceGoal_3_Click(object sender, EventArgs e)
        { swapView(1, 0); }

        private void btnPieceGoal_4_Click(object sender, EventArgs e)
        { swapView(1, 1); }

        private void btnPieceGoal_5_Click(object sender, EventArgs e)
        { swapView(1, 2); }

        private void btnPieceGoal_6_Click(object sender, EventArgs e)
        { swapView(2, 0); }

        private void btnPieceGoal_7_Click(object sender, EventArgs e)
        { swapView(2, 1); }

        private void btnPieceGoal_8_Click(object sender, EventArgs e)
        { swapView(2, 2); }
        public void printBoard(int[,]mat)
        {
            for (int x = 0; x < Constants.N; x++)
            {
                for (int y = 0; y < Constants.N; y++)
                    Console.Write(mat[x, y] + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("------------------------");
        }
        private void copyMat(int[,] source, int[,]destiny)
        {
            for (int x = 0; x < Constants.N; x++)
                for (int y = 0; y < Constants.N; y++)
                    destiny[x, y] = source[x, y];

            PieceBlankInitial[0] = PieceBlankGoal[0];
            PieceBlankInitial[1] = PieceBlankGoal[1];
        }
        private bool validatePosition(int x, int y)
        {
            if (x >= 0 && x < Constants.N && y >= 0 && y < Constants.N)
                return true;
            return false;
        }
        // Faz swap na da peça através do CLICK
        private void swapView(int x, int y)
        {
            int xBlank = PieceBlankGoal[0];
            int yBlank = PieceBlankGoal[1];
            for (int i = 0; i < 4; i++)
            {
                if (validatePosition(xBlank + row[i], yBlank + col[i])
                    && xBlank + row[i] == x
                    && yBlank + col[i] == y)
                    swap(MatGoal, xBlank, yBlank, xBlank + row[i], yBlank + col[i]);
            }
            Scrambled = false;
            loadState(BoardGoal, MatGoal);
        }
        // Faz swap na matriz de estado
        private void swap(int[,] mat, int x, int y, int newX, int newY)
        {
            int aux = mat[newX, newY];

            mat[newX, newY] = mat[x, y];
            mat[x, y] = aux;

            if(mat == MatGoal)
            {
                PieceBlankGoal[0] = newX;
                PieceBlankGoal[1] = newY;
            }
            else
                if(mat == MatInitial)
                { 
                    PieceBlankInitial[0] = newX;
                    PieceBlankInitial[1] = newY;
                } 
        }
        private void shuffle(int[,]mat, ref int x, ref int y)
        {
            Random rand = new Random();

            int randIndex, randQtd, newX, newY;
            randQtd = rand.Next(5, 50);

            copyMat(MatGoal, mat);

            for (int i = 0; i < randQtd; i++)
            {
                randIndex = rand.Next(4);
                newX = x + row[randIndex];
                newY = y + col[randIndex];

                if (validatePosition(newX, newY))
                {
                    swap(mat, x, y, newX, newY);
                    x = newX;
                    y = newY;
                }
            }
            Scrambled = true;
        }
        //Configura cores dos tabuleiros
        private void setColors(Button[,] board)
        {
            for (int x = 0; x < Constants.N; x++)
                for (int y = 0; y < Constants.N; y++)
                {
                    if (String.IsNullOrEmpty(board[x, y].Text))
                        board[x, y].BackColor = Color.Black;
                    else
                        if (board == BoardResult)
                            board[x, y].BackColor = Color.Transparent;
                        else
                            board[x, y].BackColor = Color.YellowGreen;  
                }
        }
        //Habilita botões de movimentação válida
        private void enableValidButton(Button[,] board)
        {
            int x, y;
            for (int i = 0; i < 4; i++)
            {
                x = PieceBlankGoal[0] + row[i];
                y = PieceBlankGoal[1] + col[i];
                if (validatePosition(x, y))
                    board[x, y].Enabled = true;
            }
        }
        //Carrega um estado para tela
        private void loadState(Button[,] board, int[,] state) 
        {
            for (int x = 0; x < Constants.N; x++)
                for (int y = 0; y < Constants.N; y++)
                {
                    if(state[x,y] == 0)
                        board[x, y].Text = "";
                    else
                        board[x, y].Text = Convert.ToString(state[x, y]);
                    board[x, y].Enabled = false;
                }
            setColors(board);
            if (board == BoardGoal)
                enableValidButton(BoardGoal);
            if (Scrambled)
                btnSolve.Enabled = true;
            else
                btnSolve.Enabled = false;
            log();
        }
        //Imprime o estado atual dos tabuleiros no console 
        private void log()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("BOARD INITIAL:");
            Console.WriteLine($"Blank:[{PieceBlankInitial[0]}|{PieceBlankInitial[1]}]");
            printBoard(MatInitial);

            Console.WriteLine("BOARD GOAL:");
            Console.WriteLine($"Blank:[{PieceBlankGoal[0]}|{PieceBlankGoal[1]}]");
            printBoard(MatGoal);
        }

        //Carrega as opções de algoritmos para o combobox
        private void loadComboBox(ComboBox cbox, string[] cboxItens)
        {
            for (int i = 0; i < cboxItens.Length; i++)
                cbox.Items.Add(cboxItens[i]);
            comboBoxAlgorithm.SelectedIndex = 0;
        }
        private void load_FormHome(object sender, EventArgs e)
        {
            loadState(BoardInitial, MatInitial);
            loadState(BoardGoal, MatGoal);
            loadComboBox(comboBoxAlgorithm, CboxAlgorithms);
            progressBarSolve.Visible = false;
            btnSolve.Enabled = false;
            gBoxStatistics.Visible = false;
            btnCloseStatistics.Visible = false;
        }
        private void showPathSolution(List<int[,]>path)
        {
            progressBarSolve.Minimum = 0;
            progressBarSolve.Maximum = path.Count();
            progressBarSolve.Value = 1;
            progressBarSolve.Step = 1;
            progressBarSolve.Visible = true;

            foreach (var item in path)
            {
                loadState(BoardResult, item);
                progressBarSolve.PerformStep();
                Refresh();
                Thread.Sleep(350);
            }
        }
        private void showStatistics(SolutionStatistics statistics)
        {
            if (statistics != null)
            {
                showPathSolution(statistics.Visiteds);
                txtQtdSteps.Text = $"Movimentações: {statistics.Steps}";
                txtTemp.Text = $"Tempo: {statistics.Temp} ms";
                txtPathSolutionSize.Text = $"Tam. do Caminho: {statistics.PathSolutionSize}";
                txtQtdDifferentStates.Text = $"Dif. Estados gerados: {statistics.DifferentStates}";
            }
            else
            {
                txtQtdSteps.Text = $"Limite Mov. Excedido:{Constants.maxMovements}";
                txtTemp.Visible = false;
                txtPathSolutionSize.Visible = false;
                txtQtdDifferentStates.Visible = false;
            }
            btnCloseStatistics.Visible = true;
            gBoxStatistics.Visible = true;
        }
        private void btnCloseStatistics_Click(object sender, EventArgs e)
        {
            gBoxStatistics.Visible = false;
            btnCloseStatistics.Visible = false;
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            shuffle(MatInitial, ref PieceBlankInitial[0], ref PieceBlankInitial[1]);
            loadState(BoardInitial, MatInitial);
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            App app = new App();
            int cbAlgorithmValue = comboBoxAlgorithm.SelectedIndex;
            showStatistics(app.menu(MatInitial, MatGoal, cbAlgorithmValue));
        }
    }
}
