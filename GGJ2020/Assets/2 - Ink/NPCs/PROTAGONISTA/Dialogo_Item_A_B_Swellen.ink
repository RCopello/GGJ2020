INCLUDE ../../initialization.ink

->INICIO
=== INICIO ===
Fala ai moça, {~suave na nave?|tranquilo como esquilo?|} -> ESCOLHAS #NAME_SUELLEN

=== ESCOLHAS ===
*[Puxar assunto] -> ASSUNTO
* {TEM_JORNAL}[Mostrar Item A] -> ITEM_A
* {TEM_BOLA}[Mostrar Item B] -> ITEM_B
+[Vazar] -> FIM


=== ASSUNTO === 
"E ai pequena, não reparou alguma coisa estranha na cidade hoje? #NAME_PROTAGONISTA
Na humildade moça, é difícil não reparar quando um Buracão daqueles é tampado. 
Ele tá ai no meio da cidade desde que eu nasci. Não entendo como o "seu prefeito" não tinha fechado ele até hoje.
Pois é, já estou há anos fora da cidade, e desde que sai daqui essa cratera já fazia parte da vida desse lugar. 
Esse buraco era uma desgraça! Nunca vi meu time ser campeão por causa dele! 
O que o bumbum tem a ver com as calças?
Papai sempre falava: "O "TIME" vai ser campeão no dia que fecharem aquele buraco!"
E finalmente aconteceu, só pode ser algum milagre!
Meu tio torce pro "..." , mas nunca vi eles fazerem um gol..
Espero que a TV lá de casa pare de dar interferência, daqui a pouquinho vai rolar a partida do Brasileirão.
->FIM


=== ITEM_A ===
Ela funciona mesmo??
Funciona sim, o Crispin me garantiu! Ele comprou umas antenas novas pro buteco, aí acabou se desfazendo dessas. Como tava passando por aqui, vim ver se te interessava.
Nossa moça, você é braba demais!! Claro que quero, finalmente vou poder assistir um jogo do timão de forma decente!
Alias.. Quer ir lá em casa assistir o jogo comigo?
Você não acha melhor chamar seus amigos?
É complicado moça.. as meninas odeiam futebol, e os meninos ficam tirando sarro de mim por que eu gosto de jogar. Acabo assistindo sozinha ou com o meu pai. Mas hoje ele trabalha o dia todo.
(Tadinha, acho que não faz mal dar uma relaxada do serviço)
Tudo bem, vou adorar! Vou levar uma pipoca pra gente fazer enquanto vê o jogo!
Obaaaa!!!
----((Depois do jogo acabar))----
Parece que o papai não entende nada de futebol, perdemos de novo...
Faz parte menina, não esquenta com isso não. Tenho certeza que o buraco não tem nada a ver com o campeonato, eles podem só ter dado azar mesmo.
Tranquilo.. deve ser mesmo. Mas valeu moça! Muito obrigado mesmo pela companhia! Bom te ter aqui pela cidade!

-> DONE

=== ITEM_A_TERMINADO ===
Frase de Agradecimento genêrica 

-> FIM

=== ITEM_B ===
Onde você achou isso??
Tava presa na arvoré em frente a casa da Marcia Caloteira. Ela ficou bem bolada com a situação. Quando passei ali perto, ela estava resmungando, acusando algumas "crianças encrenqueiras" de estarem arruinando a propriedade dela.
Cara, que papo é esse!? Eu isolei essa bola faz quase uma semana, ninguém conseguiu encontrar desde então.
Até por isso que os meninos me proibiram de brincar com eles..
Pra eles sou só uma garota idiota que não sabe jogar bola.
Pode ficar tranquila, tenho certeza que você ainda vai se tornar uma jogadora de futebol magnífica！ Vai deixar esses otários no chinelo! O dia que você virar a próxima Marta, eles vão implorar de joelhos para jogar com você!
Que moralzona tu tá me dando em moça,assim fico até sem graça! Acho que esses dias vou dar uma treinada! Não quero decepcionar uma pessoa tão bacana e faço questão de provar pra esses bocós quem é a dona dessa rua!
-> DONE

=== ITEM_B_TERMINADO ===
Acho que vou voltar pra casa agora. Ja esta ficando tarde, e o papai nao gosta muito que eu fique na rua ate tarde.
-> FIM

=== FIM ===
#END_DIALOGUE
então tchau!
-> INICIO
