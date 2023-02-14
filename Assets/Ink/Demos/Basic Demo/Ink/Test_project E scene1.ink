-> scene1
//-> scene_0_

==scene_0_==
Некоторый текст 1. #Tag.SomeTag_1
    +[>>]
    - Пес поднимает к тебе механизированную морду, в ожидании команд.
        +[>>]
        - Расскажи о последних вызовах для патруля.
            +[>>]
                #Quest.SomeTag_2
                    ->END
    
    
==scene1==
- Первое ночное дежурство! # Speaker.Tisha
    *[>>]
    - Пес поднимает к тебе механизированную морду, в ожидании команд. # Speaker.Storyteller
        *[Расскажи о последних вызовах для патруля.] # Speaker.Tisha
            -> scene_1_block_1
        *[Какие новости?] # Speaker.Tisha 
            -> scene_1_block_2
        *[Ладно, отставить.] # Speaker.Tisha 
            ->END

==joke==
Если бы у пса была такая техническая возможность, то он бы сейчас тяжело вздохнул. Но, вместо этого, он просто смотрит на тебя, не мигая, галогенными фарами вместо глаз. # Speaker.Storyteller
    +[>>]
-Рекомендую именно этот вызов, рядовой. #Speaker.Mukhtar
    +[>>]
-Ладно, я тебя понял. К дядь Арсену – так к дядь Арсену. #Speaker.Tisha
    +[>>]
        ->DONE

== scene_1_block_1 ==
Гражданин А.Г.Урамалян заявил о нарушениях общественного порядка возле его магазина. Участковый Дашков отказывается выезжать туда снова, говорит, что это шестой вызов за последние два дня. Приоритет низкий. # Speaker.Mukhtar
    +[Понятно, а другие вызовы есть?]  # Speaker.Tisha 
        Других вызовов нет. Для первого самостоятельного задания я рекомендую именно этот вызов, рядовой. # Speaker.Mukhtar 
            **[Как будто ты что-то рекомендовать можешь, ты же собака… Робособака. Ненастоящая даже. Неживая.] # Speaker.Tisha
                ->joke
            **[А у тебя квалификации-то хватит что-то рекомендовать? Ты же... Ну, это. Собака.] # Speaker.Speaker.Tisha 
                ->joke
            **[Знаешь, а я бы тоже хотел быть собакой. Механизированным псом, все такое.]  # Speaker.Tisha  
                ->joke
        --Ладно, я тебя понял. К дядь Арсену – так к дядь Арсену. # Speaker.Tisha
            +++[>>]
                ->DONE
    +[Ладно, отставить.] # Speaker.Tisha
->END

== scene_1_block_2 ==
{ shuffle:
    - Повышение цен на транспорт прямо пропорционально повышению спроса на капсулы. Все больше людей хотят отправиться навсегда в Бессмертие. # Speaker.Mukhtar
    - Следственный комитет занимается расследованием исчезновения главного редактора местных новостей. Говорят, что он занимался сенсационным расследованием о Корпорации. Врут. Запил. Наверно. # Speaker.Mukhtar
    - Все чаще стали появляться граффити со странным содержанием. "Ищи истину под Пологом". Выявить нарушителя общественного порядка не получается. # Speaker.Mukhtar
    - Театр закрыли из-за отсутствия спектаклей. Говорят, на месте театра будет организована аренда капсул Бессмертия. # Speaker.Mukhtar
    - В магазинах появляются синтетические продукты под видом органических. КиберПотребНадзор проверяет все товары по округу. # Speaker.Mukhtar
}
    +[>>]
-Ладно, отставить. # Speaker.Tisha
    +[>>]
        ->DONE