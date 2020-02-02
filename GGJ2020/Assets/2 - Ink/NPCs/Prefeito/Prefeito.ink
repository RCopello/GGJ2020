INCLUDE ../../inicialization.ink

-> INICIO
=== INICIO ===
Eu sou o prefeito. #NAME_Prefeito

* {CAN_NEXT_ACT} [Proximo ato] -> NEXT
+ [Continuar na scene] -> FIM 

== NEXT ==
Bora. #CanGoToNextScene
->FIM

== FIM ==
-> INICIO
    