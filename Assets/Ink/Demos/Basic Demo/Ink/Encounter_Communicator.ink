VAR CheckResult = false
VAR CheckResultStr = ""


-> Encounter_Communicator
== Encounter_Communicator ==

Коммуникатор поблескивает голо-помехами: экран старого устройства перекрывают трещины и выцветшие элементы интерфейса. Кажется, его давно пора выбросить... #Speaker.Storyteller
    * [<Позвонить в участок>] #Speaker.Tisha
        -> Encounter_Communicator_block_1
    * [<Позвонить в больницу>] #Speaker.Tisha
        -> Encounter_Communicator_block_2
    * [<Проверить сообщения Падлыча>] #Speaker.Tisha
        -> Encounter_Communicator_block_3
    * [<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
        -> Encounter_Communicator_block_END
-> END


== Encounter_Communicator_block_1 == 
Ты пытаешься дозвониться, но на другом конце сети тебя встречает лишь тишина. Кажется, сеть все еще перегружена. #Speaker.Storyteller
    * [<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
        -> Encounter_Communicator_block_END

== Encounter_Communicator_block_2 == 
Ты пытаешься дозвониться, но на другом конце сети тебя встречает лишь тишина. Кажется, сеть все еще перегружена.#Speaker.Storyteller
    * [<Позвонить в участок>] #Speaker.Tisha
- Ничего не меняется: сеть все так же перегружена.  #Speaker.Storyteller
    * [<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
        -> Encounter_Communicator_block_END

== Encounter_Communicator_block_3 == 
Несколько рекламных рассылок, пара сообщений от клиентов, интересная переписка с Госпожой… Хм, кто это? #Speaker.Storyteller
    * [<Проверить номер Госпожи>] #Speaker.Tisha
        {   CheckResult:
                -> Encounter_Communicator_block_3_1
            -else:
                -> Encounter_Communicator_block_3_else
        }
-> END

== Encounter_Communicator_block_END == 
Экран коммуникатора темнеет, и некогда умное устройство превращается в простую пластмассовую пластинку. #Speaker.Storyteller
    +[>>]
-> END

== Encounter_Communicator_block_3_1 == 
Номер скрыт. Но есть ссылка на ее личность в Виртуальной Реальности… Скопировать ссылку? #Speaker.Storyteller
    *[<Переписать ссылку на встроенный чип>] #Speaker.Tisha
        Ссылка скопирована. Что дальше? #Speaker.Storyteller
        ** [<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
            -> Encounter_Communicator_block_END
    *[<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
        -> END

== Encounter_Communicator_block_3_else ==
Номер скрыт. Увы и ах. #Speaker.Storyteller
    * [<Убрать коммуникатор до лучших времен>] #Speaker.Tisha
        -> Encounter_Communicator_block_END

