VAR CheckResult = false
VAR CheckResultStr = ""

-> scene3_2
    
== scene3_2 ==
Девочка на снегу кажется тебе игрушечной: маленькие ручки и ножки все в царапинах и наливающихся синяках, она сипло дышит и дрожит. #Speaker.Storyteller
*[Боже мой, она же совсем маленькая!] #Speaker.Tisha
    ->scene_3_2_block_1
*[Ага. Ребенок. Понятно] #Speaker.Tisha
    ->scene_3_2_block_2
*[Мне необходимо изучить капсулу.] #Speaker.Tisha #CheckSkill.Alertness.1
    ->scene_3_2_block_3

== scene_3_2_block_1 ==
Ты видишь, как перед тобой лежит израненный ребенок без сознания. #Speaker.Storyteller
    *[<Попробовать привести ребенка в сознание>] #Speaker.Tisha
        Ты пытаешься стучать по щекам ребенка, привести ее в чувства, но у тебя ничего не получается. Ей явно нужна помощь куда более квалифицированных врачей. Например, твоего старого знакомого… #Speaker.Storyteller #Note.Padlytch //#Quest.SaveAndPreserve
            ++[>>]
                ->CorrectCompletion
    *[<Изучить состояние ребенка>] #Speaker.Tisha
        Единственное, что ты понимаешь: ребенку требуется медицинская помощь. И единственный человек, который может ее тебе оказать - твой старый знакомый… #Speaker.Storyteller #Note.Padlytch  //#Quest.SaveAndPreserve
            ++[>>]
                ->CorrectCompletion

== scene_3_2_block_2 == 
Тебе, на самом деле, ничего не понятно, правда ведь? #Speaker.Storyteller
    +[>>]
-Мухтар внимательно смотрит на тебя, а затем толкает механизированной мордой в ногу, чтобы ты обратил на него внимание. #Speaker.Storyteller
    * [Надо уматывать отсюда.] #Speaker.Tisha
        Мухтар согласно кивает. Ты делаешь один взгляд в сторону каспулы, тебя к ней тянет и очень хочется прикоснуться, пусть ты и понимаешь, что это небезопасно... #Speaker.Storyteller
            ++[>>]
        --Я одним глазком только посмотрю... #Speaker.Tisha
            ++[>>]
              -> scene_3_2_block_3_1
    * [Изучить капсулу бы...] #Speaker.Tisha
        -> scene_3_2_block_3_1
    * [Отличное первое дежурство. Просто, мать его, отличное.] #Speaker.Tisha 
        Ты пытаешься стучать по щекам ребенка, привести ее в чувства, но у тебя ничего не получается. Ей явно нужна помощь квалифицированных врачей. Например, твоего старого знакомого… #Speaker.Storyteller #Note.Padlytch //#Quest.SaveAndPreserve
            ++[>>]
        ->CorrectCompletion

== scene_3_2_block_3 ==
	{ CheckResult:
        -> scene_3_2_block_3_1
    -else:
        -> scene_3_2_block_3_2
    }
->CorrectCompletion

== scene_3_2_block_3_1 ==
{CheckResultStr} Похожа на корпоратские капсулы. Только откуда им взяться здесь? Ты проводишь ладонью по нагретому корпусу и чувствуешь, что он с каждой секундой нагревается еще сильнее. #Speaker.Storyteller
    +[>>]
-Кажется, отсюда нужно уматывать. #Speaker.Tisha
    +[>>]
-Ты берешь девочку на руки и делаешь несколько шагов назад. Дым из капсулы начинает валить еще сильнее. Ты делаешь еще несколько шагов. БАБАХ! Взрывная волна заставляет тебя упасть, но ты вовремя успел отойти назад. #Speaker.Storyteller
    +[>>]
->CorrectCompletion

== scene_3_2_block_3_2 ==
{CheckResultStr} Если бы ты больше интересовался техникой, а не читал голороманы в школе, то смог бы понять, что это за капсула. Но ты не понимаешь. Единственное, что тебе становится ясно: оставаться возле нее опасно. #Speaker.Storyteller
    +[>>]
-[Изучить состояние девочки] #Speaker.Tisha
    +[>>]
-Единственное, что ты понимаешь: ребенку требуется медицинская помощь. И единственный человек, который может ее тебе оказать - твой старый знакомый… #Speaker.Storyteller #Note.Padlytch  //#Quest.SaveAndPreserve
    +[>>]
->CorrectCompletion

== CorrectCompletion ==
    + #CorrectCompletion
        ->DONE
  
== IncorrectCompletion ==
    + #IncorrectCompletion
        ->END  