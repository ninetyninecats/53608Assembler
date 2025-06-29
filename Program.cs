// This is an assembler for my assembly language
//     Copyright (C) 2025  536Cats

//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.

//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.

//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <https://www.gnu.org/licenses/>.

public class Assembler {
    public static FileStream output;
    public static void Main(string[] args) {
        if (args.Length <= 0) {
            Console.WriteLine("Please run the program with the file path " +
                              "passed in as an argument");
            System.Environment.Exit(1);
        }
        output = File.Open("output.53608", FileMode.Create);
        string[] code = File.ReadAllLines(args[0]);
        foreach (string instruction in code)
            AssembleInstruction(instruction.Split(' '));
        output.Close();
    }
    public static void AssembleInstruction(string[] instruction) {
        string opcode = instruction[0];
        string? arg1 = instruction.Length >= 2 ? instruction[1] : null;
        string? arg2 = instruction.Length >= 3 ? instruction[2] : null;

        switch (opcode) {
        case "ADD":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10000101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10000100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "SUB":
            switch (arg1[0]) {

            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10001101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10001100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "MUL":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                output.WriteByte(0b10010110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10010101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10010000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10010001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10010010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10010011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10010100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "SMUL":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                output.WriteByte(0b10011110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10011101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10011000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10011001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10011010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10011011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10011100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "DIV":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                output.WriteByte(0b10100110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10100101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10100000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10100001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10100010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10100011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10100100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "SDIV":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                output.WriteByte(0b10101110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10101101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10101000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10101001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10101010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10101011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10101100);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        case "NGT":
            switch (arg1[0]) {
            case '#':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                output.WriteByte(0b10110110);
                output.WriteByte(Convert.FromHexString(arg1.Substring(1))[0]);
                break;
            case '$':
                if (arg2 is not null)
                    throw new Exception("Invalid ADD instruction");

                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                output.WriteByte(0b10110101);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1.Substring(1))[0] * 256 +
                    Convert.FromHexString(arg1.Substring(1))[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1.Substring(1))[0] *
                                   256 +
                               Convert.FromHexString(arg1.Substring(1))[1]) >>
                           8));
                break;
            case 'A':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10110000);
                break;

            case 'B':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10110001);
                break;

            case 'C':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10110010);
                break;

            case 'D':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10110011);
                break;
            case 'P':
                if (arg1.Length != 1 || arg2 is not null)
                    throw new Exception("Invalid ADD instruction");
                output.WriteByte(0b10110011);
                break;

            default:
                throw new Exception("Unknown argument");
            }
            break;
        default:
            throw new Exception("Unknown operation" + opcode);
        }
    }
}