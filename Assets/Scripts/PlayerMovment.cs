using UnityEngine;
using UnityEngine.InputSystem;


//SHIFT + ARROW UP/ DOWN to key some lines
//click option + arrow to change the location of the line   
//Fn+F2 to rename all references
public class PlayerMovment : MonoBehaviour
{ 
    [SerializeField] float controlSpeed = 10f;   
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 3f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeefd = 10f;

    Vector2 movmentInput;

    void Update()
    {
        ProcessTranslation();
        ProccessRotation();
    }

    public void OnMove(InputValue value){

        movmentInput = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = movmentInput.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset ;

        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        float yOffset = movmentInput.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset ;

        

        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPos , clampedYPos , 0f);
    }
    void ProccessRotation()  
    {   
        float roll = -controlPitchFactor * movmentInput.x;
        float pitch = -controlRollFactor * movmentInput.y;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeefd);
    }
}
