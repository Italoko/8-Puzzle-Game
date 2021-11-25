# 8 Puzzle Game
 
## O Jogo original

Trata-se de uma pequena caixa quadrada, com 15 espaços cobertos por quinze peças também 
quadradas, que contem números, figuras ou desenhos, e um espaço vazio para que se possa 
movimentá-las. As peças devem ser ordenadas na caixa em sequência, deslocando-se as peças 
ocupando o espaço vazio, fazendo quantos movimentos quiser sem retirá-las da caixa, 
colocando-as na ordem e deixando o 16° quadradinho vazio. <br>
A popularidade do jogo fez com que ele merecesse, anos mais tarde, artigos em publicações 
científicas. Analisando o puzzle, matemáticos chegaram à seguinte conclusão: são quase vinte 
e um trilhões de configurações possíveis das peças na caixinha (21 x 10¹²).<br>
O matemático alemão Thomas J. Ahrens, especialista em passatempos, analisou o puzzle e 
concluiu que metade das 21 trilhões de configurações iniciais possíveis era vencedora (podia 
ser colocada na ordem 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 e espaço) e a outra metade, 
perdedora, isto é, seria impossível colocar todos os números na sequencia crescente. 

## Objetivo
Ordenar os quadrados, da esquerda para a direita e de cima para baixo, isto é, obter a 
disposição original dos contadores depois de terem sido aleatoriamente deslocados.

## Regras
Os blocos numerados podem ser movidos para o buraco por deslocamento da peça adjacente 
selecionada. Cada bloco é selecionado na sua vez. Os movimentos permitidos são os de 
deslocar as peças para o local vazio. Na realidade existem dois tipos de configurações iniciais 
possíveis. <br>
Um dos tipos permite a resolubilidade do puzzle enquanto que o outro provoca a 
sua insolubilidade. <br>
A configuração resolúvel pode ser obtida deslocando as peças desde a 
posição pretendida e efetuando passos para trás de forma aleatória fazendo sempre deslizar as 
peças adjacentes ao local vazio para o local vazio. <br>
A configuração insolúvel é obtida 
acrescentando aos deslocamentos a troca física de duas peças de posição.

## O projeto 8 Puzzle
Se trata de um trabalho bimestral da disciplina Inteligência artificial do curso Sistemas de 
Informação – FIPP<br>
Para esse projeto usamos uma versão menor do jogo original, um tabuleiro de 9 espaços 
[3x3].<br>
As regras continuam sendo as mesmas, e o objetivo agora é chegar ao estado final definido 
pelo jogador respeitando as regras.

## Objetivo do Projeto
Objetivo do projeto é proporcionar ao usuário uma interface de interação na qual ele possa: 
* Definir o estado final (meta) ;
* Embaralhar o estado inicial (de partida);
* Proporcionar soluções para atingir o objetivo;
* Apresentar o passo a passo feito para chegar no objetivo;
* Apresentar estatísticas sobre a solução.

## Layout
<img src="https://chi01pap001files.storage.live.com/y4m3igxqvqoEARryCLD6aFjkR0B1pNpwYRkKtEPL_OkIOy0ZNmDhc1LmiTRJwMBm4zqWhvNeV89RND3gkUoKDb5nKtP4UFOhxAt_Zp9X5JocQ7K5yeCryoPu6rX4y3XlA9XQyp0An_q5vVtAEzVMSzIKetonKkzv-wrphfHYKC_vRSbvOuZSDY6rmuQc3Ts9TNQ?width=888&height=588&cropmode=none" width="500" title="hover text">
<br>

## Solução

### A* ( A Star ) 
* O algoritmo A* usa busca em largura e Função de custo acumulado (g) + Função de Avaliação (h) como critério de escolha para qual estado seguir.
* Esse critério é dado pela equação: f(n) = g(n) + h(n). 
* Para esse caso definimos função de avalição = Quantidade de peças fora do 
lugar comparando o estado atual com estado final.

### Best-First
* O algoritmo Best-First usa busca em largura e Função de avaliação acumulado 
(h) como critério de escolha para qual estado seguir. 
* Esse critério é dado pela equação: f(n) = h(n).
* Para esse caso definimos função de avalição = Quantidade de peças fora do 
lugar comparando o estado atual com estado final.

### Branch and Bound 
* O algoritmo Branch and Bound usa busca em largura e Função de custo 
acumulado (g) como critério de escolha para qual estado seguir
* Esse critério é dado pela equação: f(n) = g(n).

### Exemplo:
Por exemplo, considerando o algoritmo A* que usa FA + FC como critério de escolha
teríamos um estado inicial: 
<br>
<img src="https://chi01pap001files.storage.live.com/y4mblmqDL5AsbTLhVTIy0NKXAl0efnWYJg9zeSBKbpbd-h8La50hXAn1JXw9NY73WJOiW9MVVOgcjfqkjrcwh9jCUz1UJul2Wnu6zMNTSYPTsxU8kwpxLPOOoPw6DJQoUCeTWETCMWFP7EpZgbgTidoxHE5DDcfXplA-fzJz7EuiZiBdQaB0kp1x_EZAVH15l2s?width=265&height=105&cropmode=none" width="350" title="hover text">
<br>
Em todas soluções, a partir de um estado inicial, é criado de 0 até 4 possíveis novos estados juntamente com seus atributos.

***0 Possíveis estados apenas se o estado inicial for igual estado final****

<img src="https://chi01pap001files.storage.live.com/y4mOIXK7-gCrUgNqMup-Bd6mNuPyfUxyH6BODHP5EfyHWwaxXqjVZferZbbT6-0mCQBhZhWBx08AzNXGgnnt7cKRiDfQzpLCXIiFSyznp_xb5oq-pHD2lg9Z1NleQWhfpptk4JiNXd1dAi9fSfhCiP6st8mSvtojpcKIfj9iFxvCcWjx2PsTDkn9CXxYqKztmy3?width=873&height=247&cropmode=none" width="350" title="hover text">
<br>

Para esse caso foi possível criar 3 novos estados seguindo as regras de movimentações do jogo, e foram criadas os estados de movimentação da peça branca “pra cima, pro lado direito, e para baixo”. <br>
Agora o algoritmo deve escolher o estado que tem a menor heuristica(f) em comparação com o estado final e que ainda não tenha passado por esse mesmo estado para continuar o percurso até encontrar a solução. <br>
E o estado escolhido, é o estado que esta circulado na figura, que consequêntemente tem a menor diferença em comparação com estado meta(final): 

<img src="https://chi01pap001files.storage.live.com/y4mJQO8HiCiDbKX5WXLeluaNYvAnzGK3DSyfvGNb3f52uFv1UFn4k_V-tgNKG-Zs1ikhjkcaIBfxWpPj3ffN1oaPgm9NkmZM6VL8rbxnrcyzEtI2ZESAFFBQEOPNFD1e5fDnTzb-NNvOhHb7mPUz3fQiotiZbBsYY4ipcE9bF1hATCi3jiMexThVQrNLOveS46r?width=549&height=262&cropmode=none" width="350" title="hover text">
<br>

Para controlar para qual estado devemos seguir, e quais já foram escolhidos usaremos duas estruturas sendo elas: 

### Fila com prioridade:
*	Armazena todos estados válidos;
*	A prioridade é o F, os estados de menor custo ficam mais proximos da cabeça da fila;

### Lista de tabuleiros:
* Armazena todos estados que já foram escolhidos 

A cada novo estado válido o processo se repete até chegar na solução (Estado meta).<br>
Seguindo esse contexto, formamos uma árvore de estados: 

<img src="https://chi01pap001files.storage.live.com/y4mGJ9jxNnAUV4hi1-5gW7iMGjUcnY-DpuzcdKbM_spNrvmaZTmr7_PKka08U_r6IX3FFhdqaeDQEuBY2tBUj0FbBIieITwkEMvPMp8ilrCX4nOi7pXW2pLhaMAzZha97KP9rHoWwaK0v53nWarcKXsRJnbYC2g4kcRN4VTM59_ill1PrelYar4aifqIyzIFmE8?width=560&height=628&cropmode=none" width="350" title="hover text">
<br>

Os estados circulados foram os estados escolhidos como caminho da solução, o estado circulado em vermelho é o estado meta. 

## Estatísticas 
* Movimentações: Representa a quantidade de movimentações feita até chegar no estado meta;
* Tamanho do caminho: Representa o tamanho do caminho da solução;
* Tempo: Tempo que demorou para encontrar a solução;
* Representa a quantidade de estados diferentes que poderiam ter sido usados como movimentação de jogo.
