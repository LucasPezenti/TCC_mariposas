using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObjectScript : MonoBehaviour
{
    public GameObject ExamineAlert;

    [SerializeField] private Transform holdSpot;
    [SerializeField] private LayerMask pickUpMask;
    private Vector3 pickDirection { get; set; }
    public GameObject itemHolding;
    private TopDownMovement PlayerMovement;

    private bool isHolding;

    private void Awake()
    {
        PlayerMovement = GetComponent<TopDownMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        itemHolding = null;
        isHolding = false;
        pickDirection = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.onDialogue)
        {
            ProcessInputs();
        }
    }

    void FixedUpdate(){
        ChangePosition();
    }

    private void ProcessInputs(){
        if (!ExamineManager.isExamining)
        {
            if (itemHolding == null && Input.GetKeyDown(KeyCode.E))
            {
                //PickUp();
            }

            else if (itemHolding != null && Input.GetKeyDown(KeyCode.E))
            {
                Release();
            }
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
                ///FindObjectOfType<ExamineManager>().OpenItemExam(itemHolding.GetComponent<PuzzleBox>().item);
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

        if (PlayerMovement.dir == Direction.right){
            holdSpot.transform.localPosition = new Vector2(0.22f, 0.58f);
        }
        else if(PlayerMovement.dir == Direction.left){
            holdSpot.transform.localPosition = new Vector2(-0.22f, 0.58f);
        }
        if(PlayerMovement.dir == Direction.up){
            holdSpot.transform.localPosition = new Vector2(0, 0.61f);
        }
        else if(PlayerMovement.dir == Direction.down){
            holdSpot.transform.localPosition = new Vector2(0, 0.53f);       
        }
    }

    public void PickUp(GameObject pickUpItem){
        /*
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + pickDirection * .35f, .15f, pickUpMask);
        if (pickUpItem)
        {
            
        }
        */
        itemHolding = pickUpItem.gameObject;
        itemHolding.transform.position = holdSpot.position;
        itemHolding.transform.parent = holdSpot.transform;
        itemHolding.GetComponent<SpriteRenderer>().enabled = false;
        if (itemHolding.GetComponent<Rigidbody2D>())
        {
            itemHolding.GetComponent<Rigidbody2D>().simulated = false;
            //Debug.Log("Item grabbed");
        }
        isHolding = true;
    }

    public void Release(){
        if(itemHolding != null)
        {
            itemHolding.transform.position = transform.position + pickDirection * .4f;
            itemHolding.transform.parent = null;
            itemHolding.GetComponent<SpriteRenderer>().enabled = true;
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
