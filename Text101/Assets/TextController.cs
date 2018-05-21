using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // Reference to the textbox to display our game text
    public Text text;

    // The possible states in our state diagram
    private enum States {cell, mirror, cell_mirror, sheets_0, sheets_1, lock_0, lock_1, corridor_0, corridor_1, corridor_2, corridor_3, stairs_0, stairs_1, stairs_2, closet_door, in_closet, floor, courtyard};

    // Our current state in the state machine
    private States currentState;
    
    //*************************************************************************
    // Use this for initialization
    void Start ()
    {
        text.text = "Hello World!";
        currentState = States.cell;

    }
    
    //*************************************************************************
    // Update is called once per frame
    void Update ()
    {
        // Call state machine functions based on current state
        if (currentState == States.cell)
        {
            state_cell();
        }
        else if (currentState == States.cell_mirror)
        {
            state_cell_mirror();
        }
        else if (currentState == States.sheets_0)
        {
            state_sheets_0();
        }
        else if (currentState == States.sheets_1)
        {
            state_sheets_1();
        }
        else if (currentState == States.mirror)
        {
            state_mirror();
        }
        else if (currentState == States.lock_0)
        {
            state_lock_0();
        }
        else if (currentState == States.lock_1)
        {
            state_lock_1();
        }
        else if (currentState == States.corridor_0)
        {
            state_corridor_0();
        }
        else if (currentState == States.corridor_1)
        {
            state_corridor_1();
        }
        else if (currentState == States.corridor_2)
        {
            state_corridor_2();
        }
        else if (currentState == States.corridor_3)
        {
            state_corridor_3();
        }
        else if (currentState == States.floor)
        {
            state_floor();
        }
        else if (currentState == States.stairs_0)
        {
            state_stairs_0();
        }
        else if (currentState == States.stairs_1)
        {
            state_stairs_1();
        }
        else if (currentState == States.stairs_2)
        {
            state_stairs_2();
        }
        else if (currentState == States.closet_door)
        {
            state_closet_door();
        }
        else if (currentState == States.in_closet)
        {
            state_in_closet();
        }
        else if (currentState == States.courtyard)
        {
            state_courtyard();
        }
    }

    //*************************************************************************
    void state_cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n" +
                    "\n" +
                    "Press S for Sheets\n" +
                    "Press M for Mirror\n" +
                    "Press L for Lock\n";
        
        if (Input.GetKeyDown("s"))
        {
            currentState = States.sheets_0;
        }
        else if (Input.GetKeyDown("m"))
        {
            currentState = States.mirror;
        }
        else if (Input.GetKeyDown("l"))
        {
            currentState = States.lock_0;
        }
    }

    //*************************************************************************
    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    " I guess!\n" +
                    "\n" +
                    "Press R to Return to romaining your cell\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.cell;
        }
    }

    //*************************************************************************
    void state_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n" +
                    "\n" + 
                    "Press T to Take the mirror\n" +
                    "Press R to Return to cell";

        if (Input.GetKeyDown("t"))
        {
            currentState = States.cell_mirror;
        }
        else if (Input.GetKeyDown("r"))
        {
            currentState = States.cell;
        }
    }

    //*************************************************************************
    void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " + 
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n" +
                    "\n" +
                    "Press R to Return to romaining your cell\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.cell;
        }
    }

    //*************************************************************************
    void state_cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " + 
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n" +
                    "\n" +
                    "Press S to view sheets\n" + 
                    "Press L to view Lock\n";

        if (Input.GetKeyDown("s"))
        {
            currentState = States.sheets_1;
        }

        if (Input.GetKeyDown("l"))
        {
            currentState = States.lock_1;
        }
    }

    //*************************************************************************
    void state_sheets_1()
    {
        text.text = "Holding a mirror in your hand doesn't make the sheets look " + 
                    "any better.\n" +
                    "\n" +
                    "Press R to Return to romaining your cell\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.cell_mirror;
        }
    }

    //*************************************************************************
    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " + 
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n" +
                    "\n" +
                    "Press O to Open\n" +
                    "Press R to Return\n";

        if (Input.GetKeyDown("o"))
        {
            currentState = States.corridor_0;
        }
        else if (Input.GetKeyDown("r"))
        {
            currentState = States.cell_mirror;
        }
    }

    //*************************************************************************
    void state_corridor_0()
    {
        text.text = "You are out of your cell, but not out of trouble." +
                    "You are in the corridor, there's a closet and some stairs leading to " +
                    "the courtyard. There's also various detritus on the floor.\n" +
                    "\n" +
                    "Press S for Stairs\n" +
                    "Press F for Floor\n" +
                    "Press C for Closet\n";

        if (Input.GetKeyDown("s"))
        {
            currentState = States.stairs_0;
        }
        else if (Input.GetKeyDown("f"))
        {
            currentState = States.floor;
        }
        else if (Input.GetKeyDown("c"))
        {
            currentState = States.closet_door;
        }
    }

    //*************************************************************************
    void state_corridor_1()
    {
        text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
                    "Now what? You wonder if that lock on the closet would succumb to " +
                    "to some lockpicking?\n" +
                    "\n" +
                    "Press S for Stairs\n" +
                    "Press P for Pick\n";

        if (Input.GetKeyDown("s"))
        {
            currentState = States.stairs_1;
        }
        else if (Input.GetKeyDown("p"))
        {
            currentState = States.in_closet;
        }
    }

    //*************************************************************************
    void state_corridor_2()
    {
        text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n" +
                    "\n" +
                    "Press S for Stairs\n" +
                    "Press B for Back\n";

        if (Input.GetKeyDown("s"))
        {
            currentState = States.stairs_2;
        }
        else if (Input.GetKeyDown("b"))
        {
            currentState = States.in_closet;
        }
    }

    //*************************************************************************
    void state_corridor_3()
    {
        text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
                    "You strongly consider the run for freedom.\n" +
                    "\n" +
                    "Press U for Undress\n" +
                    "Press S for Stairs\n";

        if (Input.GetKeyDown("s"))
        {
            currentState = States.courtyard;
        }
        else if (Input.GetKeyDown("u"))
        {
            currentState = States.in_closet;
        }
    }

    //*************************************************************************
    void state_floor()
    {
        text.text = "Rummaging around on the dirty floor, you find a hairclip.\n" +
                    "\n" +
                    "Press R to Return\n" +
                    "Press H to take the Hairclip\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_0;
        }
        if (Input.GetKeyDown("h"))
        {
            currentState = States.corridor_1;
        }
    }

    //*************************************************************************
    void state_stairs_0()
    {
        text.text = "You start walking up the stairs towards the outside light. " +
                    "You realize it's not break time, and you'll be caught immediately. " +
                    "You slither back down the stairs and reconsider.\n" +
                    "\n" +
                    "Press R to Return\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_0;
        }
    }

    //*************************************************************************
    void state_stairs_1()
    {
        text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
                    "confidence to walk out into a courtyard surrounded by armed guards!\n" +
                    "\n" +
                    "Press R to Return\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_1;
        }
    }

    //*************************************************************************
    void state_stairs_2()
    {
        text.text = "You feel smug for picking the closet door open, and are still armed with " +
                    "a hairclip (now badly bent). Even these achievements together don't give " +
                    "you the courage to clumb up the stairs to your death!\n" +
                    "\n" +
                    "Press R to Return\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_2;
        }
    }

    //*************************************************************************
    void state_closet_door()
    {
        text.text = "You are looking at a closet door, unfortunately it's locked. " +
                    "Maybe you could find something around to help enourage it open?\n" +
                    "\n" +
                    "Press R to Return\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_0;
        }
    }

    //*************************************************************************
    void state_in_closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
                    "Seems like your day is looking up.\n" +
                    "\n" +
                    "Press R to Return\n" +
                    "Press D to Dress\n";

        if (Input.GetKeyDown("r"))
        {
            currentState = States.corridor_2;
        }
        else if (Input.GetKeyDown("d"))
        {
            currentState = States.corridor_3;
        }
    }

    //*************************************************************************
    void state_courtyard()
    {
        text.text = "You walk through the courtyard dressed as a cleaner. " +
                    "The guard tips his hat at you as you waltz past, claiming " +
                    "your freedom. Your heart races as you walk into the sunset.\n" +
                    "\n" +
                    "Press P to Play Again!\n";

        if (Input.GetKeyDown("p"))
        {
            currentState = States.cell;
        }
    }
}
