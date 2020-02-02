VAR CAN_NEXT_ACT = 0

->INTRO
=== INTRO ===

Prefeito Ato 1

-> ESCOLHAS

=== ESCOLHAS ===

+ [Continuar na cidade] -> INICIO
+ {CAN_NEXT_ACT} [Ir para o proximo ato] -> FINAL

=== INICIO ===

Que seu dia em Rudânit seja maravilhoso! Converse com nossos amáveis residentes e aproveite para se enturmar.

-> FIM

=== FINAL ===

Está pronto para o segundo dia?

-> FIM


=== FIM ===

Já vai tarde.... #NAME_RICSOARES #END_DIALOGUE

->INTRO