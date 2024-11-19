=== character_dialogue ===
VAR segment_index = 1

-> load_segment

=== load_segment ===
{segment_index == 1: -> segment1}
{segment_index == 2: -> segment2}
{segment_index == 3: -> segment3}
{segment_index > 3: -> END}

== segment1 ==
Hello, traveler. It's been a while since anyone stopped by.
Why don't you stay for a moment? -> stop

== segment2 ==
I once traveled these lands too, long ago. It was a different time. -> stop

== segment3 ==
There's not much more I can tell you. Perhaps you'll figure things out. -> stop

== stop ==
~ segment_index++
-> END