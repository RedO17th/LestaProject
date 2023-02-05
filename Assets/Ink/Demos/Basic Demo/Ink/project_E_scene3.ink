VAR CheckResult = false
VAR CheckResultStr = ""

-> scene_3

== scene_3 ==
*[Нужно вызвать подмогу!]#Speaker.Tisha 
    -> scene_3_block_1
*[Мухтар, доложи обстановку!] #Speaker.Tisha #CheckSkill.Alertness.10
    -> scene_3_block_2
* [Эй, вам нужна помощь? ]#Speaker.Tisha
    -> scene_3_block_3
    
== scene_3_block_1 ==
Ты пытаешься нащупать пальцами коммуникатор для связи с участком, но не находишь его. В голове проносятся воспоминания, как Дядя Арсен обнимал тебя несколько минут назад… #Speaker.Storyteller
    + [>>]
-Дядя Арсен?! Ах ты ж старый.. #Speaker.Tisha
    + [>>]
-Из капсулы тем временем высовывается рука, и Мухтар подходит ближе, “обнюхивая” ее. #Speaker.Storyteller
    + [>>]
-Гуманоид женского пола, осмотр для установления состояния сквозь обшивку невозможен. Рекомендовано извлечь из капсулы для полноценного осмотра. #Speaker.Mukhtar
    *[На снег? А я не наврежу ей сильнее?] #Speaker.Tisha
        -> scene_3_block_1_1
    *[У тебя что, настройки слетели? Почему ты опять называешь людей гуманоидами?]  #Speaker.Tisha
        -> scene_3_block_1_2
    *[Запусти осмотр капсулы, Мухтар. И вызови наряд.] #Speaker.Tisha
        -> scene_3_block_1_3
->DONE

== scene_3_block_1_1 ==
Никак нет, рядовой. Но вот дым от капсулы вполне может ей навредить. #Speaker.Mukhtar
    + [>>]
-Ладно. Помоги мне. #Speaker.Tisha #Quest.OutOfTheBlue
    + [>>]
    ->DONE

== scene_3_block_1_2 ==
Никак нет, рядовой. Я называю гуманоидами лишь гуманоидов. #Speaker.Mukhtar
    + [>>]
-Надо тебя к дяде Валере отвести, что-то с тобой не так. #Speaker.Tisha #Quest.DontThreatenUralsky #Note.GrandfatherValera
    + [>>]
-Это не так важно сейчас. Мне кажется, что сначала надо разобраться с этой капсулой, рядовой. #Speaker.Mukhtar
    + [>>]
-Ты прав. Запусти осмотр каспулы и вызови наряд. #Speaker.Tisha
    + [>>]
        ->scene_3_block_1_3

== scene_3_block_1_3 ==
Вызов наряда недоступен. Рекомендуется вызвать по личному коммуникатору. #Speaker.Mukhtar
    + [>>]
-Нет у меня больше коммуникатора, дядь Арсен подрезал… #Speaker.Tisha
    + [>>]
-Мне занести в рапорт кражу? #Speaker.Mukhtar
    *[Сами разберемся. Зайдем на днях, поговорим.] #Speaker.Tisha #Quest.MyGrannysTangerines
        -> DONE
    *[Сейчас явно не до этого. Помоги мне!] #Speaker.Tisha #Quest.OutOfTheBlue
        -> DONE
    *[Лучше помоги этого пилота вытащить.] #Speaker.Tisha #Quest.OutOfTheBlue
        ->DONE

== scene_3_block_2 ==
	{ CheckResult:
        -> scene_3_block_2_1
    -else:
        -> scene_3_block_2_2
    }
->DONE

== scene_3_block_2_1 ==
{CheckResultStr} Эвакуационная капсула серии №376810, используется для обязательной установки на воздушные станции. На обшивке логотип, но его невозможно разглядеть. Регистрирую критические повреждения капсулы. Предположение: управление велось необученным пилотом. Регистрирую гуманоидную форму жизни в капсуле. В стабильном, но тяжелом состоянии. Рекомендуется извлечь предполагаемого пилота для установления деталей и оказания первой помощи. #Speaker.Mukhtar
    + [>>]
-Вызови наряд и скорую, я тут один не справлюсь. #Speaker.Tisha
    + [>>]
-Вызовы недоступны. Общественная сеть перегружена. #Speaker.Mukhtar
    + [>>]
-Так… Ладно. Помоги мне. #Speaker.Tisha #Quest.OutOfTheBlue
    + [>>]
        ->DONE

== scene_3_block_2_2 ==
{CheckResultStr} Регистрирую поврежденный летательный аппарат. Внутри летательного аппарата обнаружена гуманоидная форма жизни. Предположение: это пилот данного летательного аппарата. Необходима первая помощь. #Speaker.Mukhtar
    + [>>]
-Что за гуманоидная форма жизни? Человек? #Speaker.Tisha
    + [>>]
-Никак не могу знать. Смогу зарегистрировать вид только после первичного осмотра тела. #Speaker.Mukhtar
    + [>>]
-Так… Ладно. Помоги мне. #Speaker.Tisha #Quest.OutOfTheBlue
    + [>>]
->DONE

== scene_3_block_3 ==
Из капсулы не слышно ни вздоха. Ты подходишь ближе - в лицо ударяет горячий пар. Кажется, эта капсула недолго будет просто чадить дым. Ты делаешь несколько шагов назад и прикрываешь лицо рукой. #Speaker.Storyteller
    *[Мухтар, доложи обстановку!] #Speaker.Tisha
        -> scene_3_block_3_1
    *[Да что происходит-то вообще?] #Speaker.Tisha
        -> scene_3_block_3_2
    *[Надо вызвать скорую и наряд!] #Speaker.Tisha
        -> scene_3_block_3_3
->DONE

== scene_3_block_3_1 ==
Мухтар подходит к капсуле ближе, проводит по ней сканерами, а после поворачивается к тебе. #Speaker.Storyteller
    + [>>]
-Регистрирую поврежденный летательный аппарат. Внутри летательного аппарата обнаружена гуманоидная форма жизни. Предположение: это пилот данного летательного аппарата. Необходима первая помощь. #Speaker.Mukhtar
    + [>>]
-Вызови наряд и скорую, я тут один не справлюсь. #Speaker.Tisha
    + [>>]
-Вызовы недоступны. Общественная сеть перегружена. #Speaker.Mukhtar
    + [>>]
-Ладно. Сначала вытащим, а потом будем разбираться. #Speaker.Tisha #Quest.OutOfTheBlue
    + [>>]
->DONE

== scene_3_block_3_2 ==
Пока ты стоишь и не можешь придумать ничего важного и полезного, все за тебя решил сделать твой робопес. Ну и кто из вас полезный? #Speaker.Storyteller
    + [>>]
-Регистрирую поврежденный летательный аппарат. Внутри летательного аппарата обнаружена гуманоидная форма жизни. Предположение: это пилот данного летательного аппарата. Необходима первая помощь. #Speaker.Mukhtar
    + [>>]
-Вызови наряд и скорую, я тут один не справлюсь. #Speaker.Tisha
    + [>>]
-Вызовы недоступны. Общественная сеть перегружена. #Speaker.Mukhtar
    + [>>]
-Ладно. Сначала вытащим, а потом будем разбираться. #Speaker.Tisha #Quest.OutOfTheBlue
    + [>>]
->DONE

== scene_3_block_3_3 ==
Ты шаришь по карманам, но не находишь свой коммуникатор. В голове встает воспоминание, как дядя Арсен тебя крепко обнимал несколько минут назад. Его недовольство работой кибермилиции, похоже, достигло своего апогея. #Speaker.Storyteller
    + [>>]
-Мне занести в рапорт кражу? #Speaker.Mukhtar
    + [>>]
-Нет, сами разберемся. #Speaker.Tisha #Quest.MyGrannysTangerines
    + [>>]
->DONE