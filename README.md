## This is group project 15 

This project i was install all model need to run 

## Prerequisites

Ensure you have the following:

- A modern web browser (Chrome, Firefox, Safari, etc.)
- A local web server (like Python's SimpleHTTPServer, Node's http-server, etc.). Or you can use Live Server feature from VSCode
- An API key from OpenAI for API access. Or a laptop/PC with >4GB RAM

**miss model**

Follow the guide here to install llama_cpp Python <https://github.com/abetlen/llama-cpp-python>


## Start the app using OpenAI API

1. **Start the local server**

Navigate to the directory containing `index.html` and start your local server. For example, if you're using Python's SimpleHTTPServer, you can start it with the command:

```bash
python -m SimpleHTTPServer
```

If you're using Node's http-server, you can start it with the command:

```bash
http-server
```

2. **Access the application**

Open your web browser and navigate to localhost on the port your server is running. For example, if your server is running on port 8000, you would navigate to `http://localhost:8000`.

3. **Interact with the chat application**

You should now see the chat interface in your browser. You can type messages into the input field and press "Send" to interact with the chatbot.

Please note that this is a simple setup meant for local development and testing. It is not suitable for a production environment.

## Start the app using Local API

1. **Download model**

Download `llama-3.2-1b-instruct-Q5_K_M.gguf` from here <https://huggingface.co/argearriojas/Llama-3.2-1B-Instruct-Q5_K_M-GGUF/blob/main/llama-3.2-1b-instruct-q5_k_m.gguf> and put into the `Models` folder

2. **Change to venv**

If you use Linux run this command

```bash
source .venv/bin/activate
```

For user use windowns:

```bash
.venv-windows\Scripts\activate
```

3. **Run local OpenAI server**

Run the following script to run an OpenAI API server locally. The server should run at port 8000

``bash
./server.sh
```

or:

```bash
python -m llama_cpp.server --model "./models/mistral-7b-openorca.Q4_0.gguf" --chat_format chatml --n_gpu_layers 1
```
