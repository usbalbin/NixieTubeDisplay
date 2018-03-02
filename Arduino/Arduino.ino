//Number of digits in panel
#define DIGIT_COUNT 6

// Time in ms between digit updates, time taken to update
//all ditigs will be DIGIT_COUNT * DIGIT_UPDATE_RATE ms
#define DIGIT_UPDATE_RATE 10  

char digits[DIGIT_COUNT];

void setup() {
  // Clear panel
  for(int i = 0; i < DIGIT_COUNT; i++)
    digits[i] = 0;
}

void loop() {
  // put your main code here, to run repeatedly:
  update_digits();
}

void update_digits(){
  static int index = 0;
  static unsigned last = millis();
  static bool is_set_phase = true; //True => set-phase, False => enable-phase
  
  unsigned now = millis();

  if(now - last < DIGIT_UPDATE_RATE / 2)
    return;

  if(is_set_phase) {
    set_digit_data(digits[index]);
  }
  else {
    flush_to(index++);
    index %= DIGIT_COUNT;
  }
  is_set_phase = !is_set_phase;
  last = now;
}

/// This is what is called to set the value to display on the panel.
/// For example a value of 1234 will show [1][2][3][4] when DIGIT_COUNT = 4
void set_value(unsigned value) {
  for(int i = 0; i < DIGIT_COUNT; i++) {
    digits[i] = value % 10;
    value /= 10;
  }
}

void set_digit_data(int data) {
  //TODO: implement!!
}

void flush_to(int digit_index) {
  //TODO: implement!!
}
