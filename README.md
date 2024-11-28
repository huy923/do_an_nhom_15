
## Prerequisites

just make sure you have installed

cmake

https://developer.nvidia.com/cuda-downloads



## Start the app using Local API

1. **Download model**

Download `llama-3.2-1b-instruct-Q6_K_L.gguf` from here <https://huggingface.co/bartowski/Llama-3.2-1B-Instruct-GGUF/blob/main/Llama-3.2-1B-Instruct-Q6_K_L.gguf> and put into the `Models` folder

2. **Download python**

Follow the guide here to install <https://www.python.org/downloads/> if your pc python is installed skipping this step 


3. **Create file venv**

To create a new venv on python you need to run this first, but befo make sure that you 

```bash
cd do_an_nhom_15
```
and then run this

```bash
python -m venv venv
```

3. **Change to venv**

If you use Linux run this command

```bash
source .venv/bin/activate
```

For user use windows:

```bash
venv\Scripts\activate
```

4. **install model**
If you use windows run this command

```bash
python -m pip install llama-cpp-python --prefer-binary --no-cache-dir --extra-index-url=https://jllllll.github.io/llama-cpp-python-cuBLAS-wheels/AVX2/cu118
```

And make sure you have cuda installed if ypu runing this command
```bash
nvidia-smi
```
and not show anything you need to 

```bash
pip install uvicorn git-filter-repo pydantic_settings starlette_context fastapi sse_starlette

```

5. **Run local OpenAI server**

Run the following script to run an OpenAI API server locally. The server should run at port 8000

```bash
./server.sh
```

or:

```bash
    python -m llama_cpp.server --model "./models/mistral-7b-openorca.Q4_0.gguf" --chat_format chatml --n_gpu_layers 1
```
