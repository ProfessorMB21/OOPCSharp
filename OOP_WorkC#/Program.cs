﻿// roman numerals (RN)
// max number  3999 (MMCMXCIX in RN)

using OOP_WorkC_;

Roman r1 = new(10);     // X
Roman r2 = new(2);     // XX
Roman r3 = new("MI");  // 1001
Roman r4 = new("XXIX"); // 29


Roman r5 = r1 + r2;     // 30
Roman r6 = r2 * r3;     // 3800
Roman r7 = r6 - r4;     // 3781


Console.WriteLine(r5);
Console.WriteLine(r5.IntValue);
Console.WriteLine(r6);
Console.WriteLine(r6.IntValue);
Console.WriteLine(r7);
Console.WriteLine(r7.IntValue);
Console.WriteLine(r3);
Console.WriteLine(r3.IntValue);
Console.WriteLine(r4);
Console.WriteLine(r4.IntValue);
Console.WriteLine(r5);
Console.WriteLine(r5.IntValue);
Console.WriteLine(r4 - r1 + new Roman(1));
Console.WriteLine(-(r4 - r1 + new Roman(1)).IntValue);
Console.WriteLine(-r4.IntValue);


Roman r8 = new("-XI");
Console.WriteLine(r8);