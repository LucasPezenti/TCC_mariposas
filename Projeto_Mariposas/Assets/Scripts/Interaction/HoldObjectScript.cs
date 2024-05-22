using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObjectScript : MonoBehaviour
{
    public GameObject ExamineAlert;

    [SerializeField] private Transform holdSpot;
    [SerializeField] private LayerMask pickUpMask;
    private Vector3 pickDirection { get; set; }
    private GameObject itemHolding;
    private TopDownMovement PlayerMovement;

    private bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
        pickDirection = new Vector2(0,0);
        PlayerMovement = GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();   
    }

    void FixedUpdate(){
        ChangePosition();
    }

    private void ProcessInputs(){
        if(itemHolding == null && Input.GetKeyDown(KeyCode.E)){
            PickUp();
        }

        else if(itemHolding != null && Input.GetKeyDown(KeyCode.E)){
            Release();
        }

        if (itemHolding != null)
        {

            if (ExamineManager.isExamining)
            {
                ExamineAlert.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FindObjectOfType<ExamineManager>().CloseItemDisplay();
                }
            }
            else
            {
                ExamineAlert.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                FindObjectOfType<ExamineManager>().OpenItemExam(itemHolding.GetComponent<PuzzleBox>().item);
            }

        }
        else
        {
            ExamineAlert.SetActive(false);
        }

        

    }

    private void ChangePosition(){
        if (PlayerMovement.GetMoveDirection().sqrMagnitude > .1f)
        {
            pickDirection = PlayerMovement.GetMoveDirection().normalized;
        }

        if (PlayerMovement.GetDir() == Direction.right){
            holdSpot.transform.localPosition = new Vector2(0.22f, 0.58f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else if(PlayerMovement.GetDir() == Direction.left){
            holdSpot.transform.localPosition = new Vector2(-0.22f, 0.58f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if(PlayerMovement.GetDir() == Direction.up){
            holdSpot.transform.localPosition = new Vector2(0, 0.61f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else if(PlayerMovement.GetDir() == Direction.down){
            holdSpot.transform.localPosition = new Vector2(0, 0.53f);
            if(itemHolding != null) itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;        
        }
    }

    public void PickUp(){
        
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + pickDirection * .5f, .3f, pickUpMask);
        if (pickUpItem)
        {
            itemHolding = pickUpItem.gameObject;
            itemHolding.transform.position = holdSpot.position;
            itemHolding.transform.parent = holdSpot.transform;
            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                //Debug.Log("Item grabbed");
            }
            isHolding = true;
            if (PlayerMovement.GetLastDir() == Direction.down)
            {
                itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
    }

    public void Release(){
        if(itemHolding != null)
        {
            itemHolding.transform.position = transform.position + pickDirection * .5f;
            itemHolding.transform.parent = null;
            itemHolding.GetComponent<SpriteRenderer>().sortingOrder = 0;
            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
            }
            itemHolding = null;
            isHolding = false;
            //Debug.Log("Item released");
        }

    }

    public bool GetIsHolding(){
        return this.isHolding;
    }
}
