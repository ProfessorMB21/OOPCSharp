// roman numerals (RN)
// max number  3999 (MMCMXCIX in RN)

using OOP_WorkC_;

Roman r1 = new(10);     // X
Roman r2 = new(2);     // XX
Roman r3 = new("-MI");  // 1001
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


//Roman r8 = new("-XI");
//Console.WriteLine(r8);

Roman r9 = new(10);
Roman r10 = new(2);
Console.WriteLine($"div: {(new Roman("-XXX") / new Roman(-1)).IntValue}");
Roman r11 = new("-IV");
Roman r12 = new(2000);
Roman r13 = r12 + r1;
Console.WriteLine(r13);
Console.WriteLine(r13.IntValue);
Console.WriteLine(r11);
Console.WriteLine(r12);


Console.WriteLine(r13 != r10); // true

Roman r14 = (Roman)40;
Console.WriteLine(r14); // XL

Roman r15 = (Roman)"CM"; // 900
Console.WriteLine(r15.IntValue);

//Roman r16 = 11;
//Console.WriteLine(r16);

//Roman r17 = "XVI";