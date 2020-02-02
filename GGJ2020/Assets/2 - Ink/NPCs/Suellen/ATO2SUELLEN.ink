SUELEN FORMIGA ATO 

VAR Antena = 0
VAR Bola = 0

->INTRO
=== INTRO ===
Fala ai moça, {~suave na nave?|tranquilo como esquilo?|}
->ESCOLHAS

=== ESCOLHAS ===
+ [Puxar papo] -> PADRAO
* {Antena}[Mostrar Antena] -> ITEM_A
* {Bola}[Mostrar Bola] -> ITEM_B
+ {ITEM_A} [Falar da Antena] -> ITEM_A_TERMINADO
+ {ITEM_B} [Falar da Bola] -> ITEM_B_TERMINADO
+ [Meter o pé] -> FIM



=== PADRAO ===

"E ai pequena, não reparou alguma coisa estranha na cidade hoje? #NAME_PROTAGONISTA
Na humildade moça, é difícil não reparar quando um Buracão daqueles é tampado. #NAME_SUELEN
Ele tá ai no meio da cidade desde que eu nasci. Não entendo como o "seu prefeito" não tinha fechado ele até hoje. #NAME_SUELEN
Pois é, já estou há anos fora da cidade, e desde que sai daqui essa cratera já fazia parte da vida desse lugar. #NAME_PROTAGONISTA
Esse buraco era uma desgraça! Nunca vi meu time ser campeão por causa dele! #NAME_SUELEN
O que o bumbum tem a ver com as calças? 
Papai sempre falava: "Rudanenses Alados" vai ser campeão no dia que fecharem aquele buraco!" #NAME_SUELEN
E finalmente aconteceu, só pode ser algum milagre! #NAME_SUELEN
Meu tio torce pro "Rudanenses Alados" , mas nunca vi eles fazerem um gol.. #NAME_SUELEN
Espero que a TV lá de casa pare de dar interferência, daqui a pouquinho vai rolar a partida do Brasileirão. #NAME_SUELEN

->ESCOLHAS

=== ITEM_A ===

Ela funciona mesmo?? #NAME_SUELEN
Funciona sim, o Crispin me garantiu! Ele comprou umas antenas novas pro buteco, aí acabou se desfazendo dessas. Como tava passando por aqui, vim ver se te interessava. #NAME_PROTAGONISTA
Nossa moça, você é braba demais!! Claro que quero, finalmente vou poder assistir um jogo do timão de forma decente! #NAME_SUELEN
Alias.. Quer ir lá em casa assistir o jogo comigo?
Você não acha melhor chamar seus amigos? #NAME_PROTAGONISTA
É complicado moça.. as meninas odeiam futebol, e os meninos ficam tirando sarro de mim por que eu gosto de jogar. Acabo assistindo sozinha ou com o meu pai. Mas hoje ele trabalha o dia todo. #NAME_SUELEN
(Tadinha, acho que não faz mal dar uma relaxada do serviço) #NAME_PROTAGONISTA
Tudo bem, vou adorar! Vou levar uma pipoca pra gente fazer enquanto vê o jogo! #NAME_PROTAGONISTA
Obaaaa!!! #NAME_SUELEN
----((Depois do jogo acabar))----
Parece que o papai não entende nada de futebol, perdemos de novo... #NAME_SUELEN
Faz parte menina, não esquenta com isso não. Tenho certeza que o buraco não tem nada a ver com o campeonato, eles podem só ter dado azar mesmo. #NAME_PROTAGONISTA
Tranquilo.. deve ser mesmo. Mas valeu moça! Muito obrigado mesmo pela companhia! Bom te ter aqui pela cidade! #NAME_SUELEN

-> FIM

=== ITEM_A_TERMINADO ===

Mesmo o timão perdendo de novo ver ele com você foi muito divertido. Valeu! #NAME_SUELEN

-> ESCOLHAS

=== ITEM_B ===

Onde você achou isso?? #NAME_SUELEN
Tava presa na arvoré em frente a casa da Marcia Caloteira. Ela ficou bem bolada com a situação. Quando passei ali perto, ela estava resmungando, acusando algumas "crianças encrenqueiras" de estarem arruinando a propriedade dela.
Cara, que papo é esse!? Eu isolei essa bola faz quase uma semana, ninguém conseguiu encontrar desde então. #NAME_SUELEN
Até por isso que os meninos me proibiram de brincar com eles.. #NAME_SUELEN
Pra eles sou só uma garota idiota que não sabe jogar bola.#NAME_SUELEN
Pode ficar tranquila, tenho certeza que você ainda vai se tornar uma jogadora de futebol magnífica！ Vai deixar esses otários no chinelo! O dia que você virar a próxima Marta, eles vão implorar de joelhos para jogar com você!
Que moralzona tu tá me dando em moça,assim fico até sem graça! Acho que esses dias vou dar uma treinada! Não quero decepcionar uma pessoa tão bacana e faço questão de provar pra esses bocós quem é a dona dessa rua!

->FIM

=== ITEM_B_TERMINADO ===

Acho que vou voltar pra casa agora. Ja esta ficando tarde, e o papai nao gosta muito que eu fique na rua ate tarde. #NAME_SUELEN

-> ESCOLHAS

=== FIM ===
Té depois tia! #NAME_SUELEN #END_DIALOGUE
->INTRO